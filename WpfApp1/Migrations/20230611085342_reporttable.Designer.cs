﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WpfApp1.Database;

#nullable disable

namespace WpfApp1.Migrations
{
    [DbContext(typeof(Repository))]
    [Migration("20230611085342_reporttable")]
    partial class reporttable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("WpfApp1.Models.DoctorC", b =>
                {
                    b.Property<int>("DoctorID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Payment")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("DoctorID");

                    b.ToTable("DoctorTable", (string)null);
                });

            modelBuilder.Entity("WpfApp1.Models.DoctorReport", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("AdditionalNotes")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("AnyMedication")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AnyPastSurgeries")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ChiefComplaint")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Complications")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DateOfBirth")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DateOfSurgery")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Diagnosis")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Hospitals")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsSurgeryRequired")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MedicalString")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Medications")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PatientName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Years")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ReportTable", (string)null);
                });

            modelBuilder.Entity("WpfApp1.Models.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Disease")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("DoctorID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PatientName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Payment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PatientId");

                    b.HasIndex("DoctorID");

                    b.ToTable("PatientTable", (string)null);
                });

            modelBuilder.Entity("WpfApp1.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Occupation")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("UserTable", (string)null);
                });

            modelBuilder.Entity("WpfApp1.Models.DoctorReport", b =>
                {
                    b.HasOne("WpfApp1.Models.Patient", "Patient")
                        .WithOne("DoctorReport")
                        .HasForeignKey("WpfApp1.Models.DoctorReport", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("WpfApp1.Models.Patient", b =>
                {
                    b.HasOne("WpfApp1.Models.DoctorC", "Doctor")
                        .WithMany("Patients")
                        .HasForeignKey("DoctorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("WpfApp1.Models.DoctorC", b =>
                {
                    b.Navigation("Patients");
                });

            modelBuilder.Entity("WpfApp1.Models.Patient", b =>
                {
                    b.Navigation("DoctorReport")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
