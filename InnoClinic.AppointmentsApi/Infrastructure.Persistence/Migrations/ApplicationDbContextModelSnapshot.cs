﻿// <auto-generated />
using System;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.Entities.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("OfficeId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<int>("SpecializationId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("IsDeleted")
                        .HasFilter("[IsDeleted] = 0");

                    b.HasIndex("OfficeId");

                    b.HasIndex("PatientId");

                    b.HasIndex("ServiceId");

                    b.HasIndex("SpecializationId");

                    b.HasIndex("StatusId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Domain.Models.Entities.AppointmentStatus", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusId"));

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.ToTable("AppointmentStatuses");

                    b.HasData(
                        new
                        {
                            StatusId = 1,
                            Status = "Approved"
                        },
                        new
                        {
                            StatusId = 2,
                            Status = "Pending"
                        },
                        new
                        {
                            StatusId = 3,
                            Status = "Canceled"
                        });
                });

            modelBuilder.Entity("Domain.Models.Entities.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AppointmentStatusStatusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CareerStartYear")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OfficeId")
                        .HasColumnType("int");

                    b.Property<string>("PhotoFilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpecializationId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentStatusStatusId");

                    b.HasIndex("OfficeId");

                    b.HasIndex("SpecializationId");

                    b.HasIndex("StatusId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("Domain.Models.Entities.DoctorStatus", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusId"));

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.ToTable("DoctorStatuses");

                    b.HasData(
                        new
                        {
                            StatusId = 1,
                            Status = "At work"
                        },
                        new
                        {
                            StatusId = 2,
                            Status = "On vacation"
                        },
                        new
                        {
                            StatusId = 3,
                            Status = "Sick Day"
                        },
                        new
                        {
                            StatusId = 4,
                            Status = "Sick Leave"
                        },
                        new
                        {
                            StatusId = 5,
                            Status = "Self-isolation"
                        },
                        new
                        {
                            StatusId = 6,
                            Status = "Leave without pay"
                        },
                        new
                        {
                            StatusId = 7,
                            Status = "Inactive"
                        });
                });

            modelBuilder.Entity("Domain.Models.Entities.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StackTrace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("Domain.Models.Entities.Office", b =>
                {
                    b.Property<int>("OfficeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OfficeId"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HouseNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OfficeNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoFilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OfficeId");

                    b.HasIndex("StatusId");

                    b.ToTable("Offices");
                });

            modelBuilder.Entity("Domain.Models.Entities.OfficeStatus", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusId"));

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.ToTable("OfficeStatuses");

                    b.HasData(
                        new
                        {
                            StatusId = 1,
                            Status = "Active"
                        },
                        new
                        {
                            StatusId = 2,
                            Status = "Inactive"
                        });
                });

            modelBuilder.Entity("Domain.Models.Entities.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoFilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted")
                        .HasFilter("[IsDeleted] = 0");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Domain.Models.Entities.Receptionist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OfficeId")
                        .HasColumnType("int");

                    b.Property<string>("PhotoFilePath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted")
                        .HasFilter("[IsDeleted] = 0");

                    b.HasIndex("OfficeId");

                    b.ToTable("Receptionists");
                });

            modelBuilder.Entity("Domain.Models.Entities.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceId"));

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("ServiceCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("ServiceId");

                    b.HasIndex("ServiceCategoryId");

                    b.HasIndex("StatusId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Domain.Models.Entities.ServiceCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("ServiceCategories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Analyses"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Consultation"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Diagnostics"
                        });
                });

            modelBuilder.Entity("Domain.Models.Entities.ServiceStatus", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusId"));

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.ToTable("ServiceStatuses");

                    b.HasData(
                        new
                        {
                            StatusId = 1,
                            Status = "Active"
                        },
                        new
                        {
                            StatusId = 2,
                            Status = "Inactive"
                        });
                });

            modelBuilder.Entity("Domain.Models.Entities.Specialization", b =>
                {
                    b.Property<int>("SpecializationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SpecializationId"));

                    b.Property<string>("SpecializationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("SpecializationId");

                    b.HasIndex("StatusId");

                    b.ToTable("Specializations");
                });

            modelBuilder.Entity("Domain.Models.Entities.SpecializationStatus", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusId"));

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.ToTable("SpecializationStatuses");

                    b.HasData(
                        new
                        {
                            StatusId = 1,
                            Status = "Active"
                        },
                        new
                        {
                            StatusId = 2,
                            Status = "Inactive"
                        });
                });

            modelBuilder.Entity("Domain.Models.Entities.Appointment", b =>
                {
                    b.HasOne("Domain.Models.Entities.Doctor", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Models.Entities.Office", "Office")
                        .WithMany("Appointments")
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Entities.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Entities.Service", "Service")
                        .WithMany("Appointments")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Entities.Specialization", "Specialization")
                        .WithMany("Appointments")
                        .HasForeignKey("SpecializationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Entities.AppointmentStatus", "Status")
                        .WithMany("Appointments")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Office");

                    b.Navigation("Patient");

                    b.Navigation("Service");

                    b.Navigation("Specialization");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Domain.Models.Entities.Doctor", b =>
                {
                    b.HasOne("Domain.Models.Entities.AppointmentStatus", null)
                        .WithMany("Doctors")
                        .HasForeignKey("AppointmentStatusStatusId");

                    b.HasOne("Domain.Models.Entities.Office", "Office")
                        .WithMany("Doctors")
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Models.Entities.Specialization", "Specialization")
                        .WithMany("Doctors")
                        .HasForeignKey("SpecializationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Entities.DoctorStatus", "Status")
                        .WithMany("Doctors")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Office");

                    b.Navigation("Specialization");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Domain.Models.Entities.Office", b =>
                {
                    b.HasOne("Domain.Models.Entities.OfficeStatus", "OfficeStatus")
                        .WithMany("Offices")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OfficeStatus");
                });

            modelBuilder.Entity("Domain.Models.Entities.Receptionist", b =>
                {
                    b.HasOne("Domain.Models.Entities.Office", "Office")
                        .WithMany("Receptionists")
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Office");
                });

            modelBuilder.Entity("Domain.Models.Entities.Service", b =>
                {
                    b.HasOne("Domain.Models.Entities.ServiceCategory", "ServiceCategory")
                        .WithMany("Services")
                        .HasForeignKey("ServiceCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Entities.ServiceStatus", "Status")
                        .WithMany("Services")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ServiceCategory");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Domain.Models.Entities.Specialization", b =>
                {
                    b.HasOne("Domain.Models.Entities.SpecializationStatus", "Status")
                        .WithMany("Specializations")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Domain.Models.Entities.AppointmentStatus", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("Domain.Models.Entities.Doctor", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Domain.Models.Entities.DoctorStatus", b =>
                {
                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("Domain.Models.Entities.Office", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Doctors");

                    b.Navigation("Receptionists");
                });

            modelBuilder.Entity("Domain.Models.Entities.OfficeStatus", b =>
                {
                    b.Navigation("Offices");
                });

            modelBuilder.Entity("Domain.Models.Entities.Patient", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Domain.Models.Entities.Service", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Domain.Models.Entities.ServiceCategory", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("Domain.Models.Entities.ServiceStatus", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("Domain.Models.Entities.Specialization", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("Domain.Models.Entities.SpecializationStatus", b =>
                {
                    b.Navigation("Specializations");
                });
#pragma warning restore 612, 618
        }
    }
}
