using Application.Mappers;
using HealthChecks.UI.Client;
using InnoClinic.AppointmentsApi.Extentions;
using InnoClinic.AppointmentsApi.Middleware;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
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
            builder.Services.ConfigureValidators();
            builder.Services.ConfigureHostedServices();
            builder.Services.ConfigureSwagger();

            builder.Services.ConfigureQuartz();

            builder.Services.AddControllers();
            builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            builder.Services.AddHealthChecks()
                .AddSqlServer(builder.Configuration.GetConnectionString("sqlConnection")!)
                .AddRabbitMQ(rabbitConnectionString: builder.Configuration.GetConnectionString("rabbitmqConnection")!);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithExposedHeaders("X-Pagination");
                    });
            });

            builder.Services.AddAuthentication(config =>
            {
                config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer("Bearer", opt =>
                {
                    opt.Authority = "https://localhost:7104";
                    opt.Audience = "InnoClinicWebApi";
                    opt.RequireHttpsMetadata = false;
                });

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
            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();

            app.MapHealthChecks("/_health", new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}