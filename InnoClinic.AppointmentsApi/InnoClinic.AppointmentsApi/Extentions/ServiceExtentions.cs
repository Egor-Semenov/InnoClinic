﻿using Application.Resourses.Commands.Appointments.Approve;
using Application.Services;
using Application.Services.Interfaces;
using Domain.Interfaces.Repositories;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
        }

        public static void ConfigureCommandsAndQueriesHandlers(this IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromAssembliesOf(typeof(ApproveAppointmentCommandHandler), typeof(LoggerDbService))
                .AddClasses(classes => classes.AssignableTo(typeof(IRequestHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            services.AddScoped<ILoggerDbService, LoggerDbService>();
        }
    }
}
