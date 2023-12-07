using Application.Resourses.Commands.Appointments;
using Application.Resourses.Commands.Doctors;
using Application.Resourses.Commands.Patients;
using Application.Resourses.Commands.Receptionists;
using Application.Resourses.Commands.Services;
using Application.Resourses.Commands.Specializations;
using Application.Resourses.Queries.Appointments;
using Application.Resourses.Queries.Doctors;
using Domain.Models.Entities;
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
            builder.Services.ConfigureSqlConnection(builder.Configuration);
            builder.Services.ConfigureRepositories();

            builder.Services.AddTransient<IRequestHandler<CreateAppointmentCommand, Appointment>, CreateAppointmentCommandHandler>();
            builder.Services.AddTransient<IRequestHandler<DeleteAppointmentCommand, Appointment>, DeleteAppointmentCommandHandler>();
            builder.Services.AddTransient<IRequestHandler<ApproveAppointmentCommand, Appointment>, ApproveAppointmentCommandHandler>();
            builder.Services.AddTransient<IRequestHandler<GetAppointmentByIdQuery, Appointment>, GetAppointmentByIdQueryHandler>();

            builder.Services.AddTransient<IRequestHandler<CreateDoctorCommand, Doctor>, CreateDoctorCommandHandler>();
            builder.Services.AddTransient<IRequestHandler<ChangeDoctorStatusCommand, Doctor>, ChangeDoctorStatusCommandHandler>();
            builder.Services.AddTransient<IRequestHandler<UpdateDoctorCommand, Doctor>, UpdateDoctorCommandHandler>();
            builder.Services.AddTransient<IRequestHandler<GetDoctorByIdQuery, Doctor>, GetDoctorByIdQueryHandler>();

            builder.Services.AddTransient<IRequestHandler<CreatePatientCommand, Patient>, CreatePatientCommandHandler>();
            builder.Services.AddTransient<IRequestHandler<DeletePatientCommand, Patient>, DeletePatientCommandHandler>();
            builder.Services.AddTransient<IRequestHandler<UpdatePatientCommand, Patient>, UpdatePatientCommandHandler>();

            builder.Services.AddTransient<IRequestHandler<CreateReceptionistCommand, Receptionist>, CreateReceptionistCommandHandler>();
            builder.Services.AddTransient<IRequestHandler<DeleteReceptionistCommand, Receptionist>, DeleteReceptionistCommandHandler>();
            builder.Services.AddTransient<IRequestHandler<UpdateReceptionistCommand, Receptionist>, UpdateReceptionistCommandHandler>();

            builder.Services.AddTransient<IRequestHandler<CreateSpecializationCommand, Specialization>, CreateSpecializationCommandHandler>();
            builder.Services.AddTransient<IRequestHandler<ChangeSpecializationStatusCommand, Specialization>, ChangeSpecializationStatusCommandHandler>();
            builder.Services.AddTransient<IRequestHandler<UpdateSpecializationCommand, Specialization>, UpdateSpecializationCommandHandler>();

            builder.Services.AddTransient<IRequestHandler<CreateServiceCommand, Service>, CreateServiceCommandHandler>();
            builder.Services.AddTransient<IRequestHandler<ChangeServiceStatusCommand, Service>, ChangeServiceStatusCommandHandler>();
            builder.Services.AddTransient<IRequestHandler<UpdateServiceCommand, Service>, UpdateServiceCommandHandler>();

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