using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Contexts
{
    public sealed class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppointmentStatus>()
                .HasKey(x => new { x.StatusId });

            modelBuilder.Entity<Specialization>()
                .HasKey(x => new { x.SpecializationId });

            modelBuilder.Entity<Service>()
                .HasKey(x => new { x.ServiceId });

            modelBuilder.Entity<Specialization>()
                .HasMany(x => x.Appointments)
                .WithOne(x => x.Specialization)
                .HasForeignKey(x => x.SpecializationId);

            modelBuilder.Entity<Service>()
                .HasMany(x => x.Appointments)
                .WithOne(x => x.Service)
                .HasForeignKey(x => x.ServiceId);

            modelBuilder.Entity<AppointmentStatus>()
                .HasMany(x => x.Appointments)
                .WithOne(x => x.Status)
                .HasForeignKey(x => x.StatusId);

            modelBuilder.Entity<Specialization>()
                .HasData(new Specialization
                {
                    SpecializationId = 1,
                    SpecializationName = "Pediatrics"
                });

            modelBuilder.Entity<Service>()
                .HasData(new Service
                {
                    ServiceId = 101,
                    ServiceName = "PediatricCheckup",
                    ServiceCost = 100
                });

            modelBuilder.Entity<AppointmentStatus>()
                .HasData(new AppointmentStatus
                {
                    StatusId = 3,
                    Status = "Pending"
                });
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentStatus> AppointmentStatuses { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Service> Services { get; set; }
    }
}
