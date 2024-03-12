using Application.RabbitMQ.Interfaces;
using Application.RabbitMQ.Producers;
using Application.RabbitMQ.Subscribers;
using Application.Resourses.Commands.Appointments.Approve;
using Application.Services;
using Application.Services.Interfaces;
using Application.Validators;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories;
using InnoClinic.BackgroundJobs.Jobs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Quartz;

namespace InnoClinic.AppointmentsApi.Extentions
{
    public static class ServiceExtentions
    {
        public static void ConfigureSqlConnection(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<ApplicationDbContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"), b =>
                    b.MigrationsAssembly("Infrastructure.Persistence")));

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Place to add JWT with Bearer",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                s.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Name = "Bearer",
                        },
                        new List<string>()
                    }
                });
            });
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromAssembliesOf(typeof(AppointmentsRepository))
                .AddClasses(classes => classes.AssignableTo(typeof(IBaseRepository<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            services.AddScoped<ILogRepository, LogsRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void ConfigureCommandsAndQueriesHandlers(this IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromAssembliesOf(typeof(ApproveAppointmentCommandHandler))
                .AddClasses(classes => classes.AssignableTo(typeof(IRequestHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            services.AddScoped<ILoggerDbService, LoggerDbService>();
            services.AddScoped<IUserProfilesMessageProducer, UserProfilesProducer>();
        }

        public static void ConfigureValidators(this IServiceCollection services)
        {
            services.Scan(scan => scan
            .FromAssembliesOf(typeof(DoctorCreationValidator))
            .AddClasses(classes => classes.AssignableTo(typeof(IValidator<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        }

        public static void ConfigureQuartz(this IServiceCollection services)
        {
            services.AddQuartz(opt =>
            {
                var jobKey = "DeleteJob";
                opt.AddJob<DeleteJob>(opt => opt.WithIdentity(jobKey));
                opt.AddTrigger(opt =>
                {
                    opt.ForJob(jobKey)
                    .WithIdentity("DeleteJobTrigger")
                    .WithCronSchedule(CronScheduleBuilder.DailyAtHourAndMinute(12, 0));
                });
            });

            services.AddQuartzHostedService(config => config.WaitForJobsToComplete = true);
        }

        public static void ConfigureHostedServices(this IServiceCollection services)
        {
            services.AddHostedService<PatientCreatedSubscriber>();
            services.AddHostedService<DeadLettersSubscriber>();
        }
    }
}
