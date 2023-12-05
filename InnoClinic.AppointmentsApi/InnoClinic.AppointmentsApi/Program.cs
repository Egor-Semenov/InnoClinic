
using Application.Resourses.Commands.Appointments;
using Application.Resourses.Queries.Appointments;
using Domain.Models.Entities;
using InnoClinic.AppointmentsApi.Extentions;
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
            builder.Services.AddTransient<IRequestHandler<GetAppointmentByIdQuery, Appointment>, GetAppointmentByIdQueryHandler>();

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

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}