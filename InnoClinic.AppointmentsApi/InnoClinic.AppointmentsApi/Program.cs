using Application.DTOs.Offices;
using Application.Mappers;
using Application.Resourses.Commands.Appointments.Approve;
using Application.Resourses.Commands.Appointments.Create;
using Application.Resourses.Commands.Appointments.Delete;
using Application.Resourses.Commands.Doctors.ChangeStatus;
using Application.Resourses.Commands.Doctors.Create;
using Application.Resourses.Commands.Doctors.Update;
using Application.Resourses.Commands.Offices.ChangeStatus;
using Application.Resourses.Commands.Offices.Create;
using Application.Resourses.Commands.Offices.Update;
using Application.Resourses.Commands.Patients.Create;
using Application.Resourses.Commands.Patients.Delete;
using Application.Resourses.Commands.Patients.Update;
using Application.Resourses.Commands.Receptionists.Create;
using Application.Resourses.Commands.Receptionists.Delete;
using Application.Resourses.Commands.Receptionists.Update;
using Application.Resourses.Commands.Services.ChangeStatus;
using Application.Resourses.Commands.Services.Create;
using Application.Resourses.Commands.Services.Update;
using Application.Resourses.Commands.Specializations.ChangeStatus;
using Application.Resourses.Commands.Specializations.Create;
using Application.Resourses.Commands.Specializations.Update;
using Application.Resourses.Queries.Appointments;
using Application.Resourses.Queries.Doctors;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using Infrastructure.Persistence.Repositories;
using InnoClinic.AppointmentsApi.Extentions;
using InnoClinic.AppointmentsApi.Middleware;
using MediatR;
using System.Reflection;

namespace InnoClinic.AppointmentsApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAutoMapper(typeof(OfficesMapper));
            builder.Services.ConfigureSqlConnection(builder.Configuration);
            builder.Services.ConfigureRepositories();
            builder.Services.ConfigureCommandsAndQueriesHandlers();

            builder.Services.AddControllers();
            builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}