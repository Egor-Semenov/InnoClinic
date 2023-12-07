﻿using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories;
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
            services.AddScoped<IBaseRepository<Appointment>, AppointmentsRepository>();
            services.AddScoped<IBaseRepository<Doctor>, DoctorsRepository>();
            services.AddScoped<IBaseRepository<Patient>, PatientsRepository>();
            services.AddScoped<IBaseRepository<Receptionist>, ReceptionistRepository>();
            services.AddScoped<IBaseRepository<Service>, ServicesRepository>();
            services.AddScoped<IBaseRepository<Specialization>, SpecializationsRepository>();
        }
    }
}
