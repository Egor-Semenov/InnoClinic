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
using Quartz;

namespace InnoClinic.AppointmentsApi.Extentions
{
    public static class ServiceExtentions
    {
        public static void ConfigureSqlConnection(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<ApplicationDbContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"), b =>
                    b.MigrationsAssembly("Infrastructure.Persistence")));

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
                    .WithCronSchedule(CronScheduleBuilder.CronSchedule("0/5 * * ? * *"));
                });
            });

            services.AddQuartzHostedService(config => config.WaitForJobsToComplete = true);
        }
    }
}
