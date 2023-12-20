using Domain.Models.Entities;
using Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Contexts
{
    public sealed class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.AddInterceptors(new SoftDeleteInterceptor());

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
                .HasQueryFilter(x => x.IsDeleted == false);

            modelBuilder.Entity<Patient>()
                .HasQueryFilter(x => x.IsDeleted == false);

            modelBuilder.Entity<Receptionist>()
                .HasQueryFilter(x => x.IsDeleted == false);

            modelBuilder.Entity<AppointmentStatus>()
                .HasKey(x => new { x.StatusId });

            modelBuilder.Entity<Specialization>()
                .HasKey(x => new { x.SpecializationId });

            modelBuilder.Entity<Service>()
                .HasKey(x => new { x.ServiceId });
            
            modelBuilder.Entity<ServiceStatus>()
                .HasKey(x => new { x.StatusId });

            modelBuilder.Entity<ServiceCategory>()
               .HasKey(x => new { x.CategoryId });

            modelBuilder.Entity<DoctorStatus>()
                .HasKey(x => new { x.StatusId });

            modelBuilder.Entity<SpecializationStatus>()
                .HasKey(x => new { x.StatusId });

            modelBuilder.Entity<Office>()
                .HasKey(x => new { x.OfficeId });

            modelBuilder.Entity<OfficeStatus>()
                .HasKey(x => new { x.StatusId });

            modelBuilder.Entity<Doctor>()
                .HasMany(x => x.Appointments)
                .WithOne(x => x.Doctor)
                .HasForeignKey(x => x.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Patient>()
                .HasMany(x => x.Appointments)
                .WithOne(x => x.Patient)
                .HasForeignKey(x => x.PatientId);

            modelBuilder.Entity<Specialization>()
                .HasMany(x => x.Appointments)
                .WithOne(x => x.Specialization)
                .HasForeignKey(x => x.SpecializationId);

            modelBuilder.Entity<Specialization>()
                .HasMany(x => x.Doctors)
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

            modelBuilder.Entity<SpecializationStatus>()
                .HasMany(x => x.Specializations)
                .WithOne(x => x.Status)
                .HasForeignKey(x => x.StatusId);

            modelBuilder.Entity<ServiceStatus>()
                .HasMany(x => x.Services)
                .WithOne(x => x.Status)
                .HasForeignKey(x => x.StatusId);

            modelBuilder.Entity<DoctorStatus>()
                .HasMany(x => x.Doctors)
                .WithOne(x => x.Status)
                .HasForeignKey(x => x.StatusId);

            modelBuilder.Entity<ServiceCategory>()
                .HasMany(x => x.Services)
                .WithOne(x => x.ServiceCategory)
                .HasForeignKey(x => x.ServiceCategoryId);

            modelBuilder.Entity<Office>()
                .HasMany(x => x.Doctors)
                .WithOne(x => x.Office)
                .HasForeignKey(x => x.OfficeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Office>()
                .HasMany(x => x.Receptionists)
                .WithOne(x => x.Office)
                .HasForeignKey(x => x.OfficeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Office>()
                .HasMany(x => x.Appointments)
                .WithOne(x => x.Office)
                .HasForeignKey(x => x.OfficeId);

            modelBuilder.Entity<OfficeStatus>()
                .HasMany(x => x.Offices)
                .WithOne(x => x.OfficeStatus)
                .HasForeignKey(x => x.StatusId);

            modelBuilder.Entity<AppointmentStatus>()
                .HasData(new[]
                {
                    new AppointmentStatus
                    {
                        StatusId = 1,
                        Status = "Approved"
                    },
                    new AppointmentStatus
                    {
                        StatusId = 2,
                        Status = "Pending"
                    },
                    new AppointmentStatus
                    {
                        StatusId = 3,
                        Status = "Canceled"
                    }
                });

            modelBuilder.Entity<DoctorStatus>()
                .HasData(new[]
                {
                    new DoctorStatus
                    {
                        StatusId = 1,
                        Status = "At work"
                    },
                    new DoctorStatus
                    {
                        StatusId = 2,
                        Status = "On vacation"
                    },
                    new DoctorStatus
                    {
                        StatusId = 3,
                        Status = "Sick Day"
                    },
                    new DoctorStatus
                    {
                        StatusId = 4,
                        Status = "Sick Leave"
                    },
                    new DoctorStatus
                    {
                        StatusId = 5,
                        Status = "Self-isolation"
                    },
                    new DoctorStatus
                    {
                        StatusId = 6,
                        Status = "Leave without pay"
                    },
                    new DoctorStatus
                    {
                        StatusId = 7,
                        Status = "Inactive"
                    },
                });

            modelBuilder.Entity<SpecializationStatus>()
                .HasData(new[]
                {
                    new SpecializationStatus
                    {
                        StatusId = 1,
                        Status = "Active"
                    },
                    new SpecializationStatus
                    {
                        StatusId = 2,
                        Status = "Inactive"
                    }
                });

            modelBuilder.Entity<ServiceStatus>()
                .HasData(new[]
                {
                    new ServiceStatus
                    {
                        StatusId = 1,
                        Status = "Active"
                    },
                    new ServiceStatus
                    {
                        StatusId = 2,
                        Status = "Inactive"
                    }
                });

            modelBuilder.Entity<ServiceCategory>()
                .HasData(new[]
                {
                    new ServiceCategory
                    {
                        CategoryId = 1,
                        CategoryName = "Analyses"
                    },
                    new ServiceCategory
                    {
                        CategoryId = 2,
                        CategoryName = "Consultation"
                    },
                    new ServiceCategory
                    {
                        CategoryId = 3,
                        CategoryName = "Diagnostics"
                    }
                });

            modelBuilder.Entity<OfficeStatus>()
                .HasData(new[]
                {
                    new OfficeStatus
                    {
                        StatusId = 1,
                        Status = "Active"
                    },
                    new OfficeStatus
                    {
                        StatusId = 2,
                        Status = "Inactive"
                    }
                });
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentStatus> AppointmentStatuses { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<SpecializationStatus> SpecializationStatuses { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<ServiceStatus> ServiceStatuses { get; set; }
        public DbSet<Receptionist> Receptionists { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorStatus> DoctorStatuses { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<OfficeStatus> OfficeStatuses { get; set; }
        public DbSet<Log> Logs { get; set; }
    }
}
