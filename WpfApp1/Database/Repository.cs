using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WpfApp1.Models;

namespace WpfApp1.Database
{
    public class Repository : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<DoctorC> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<DoctorReport> DoctorReports { get; set; }

        private readonly string _path = @"E:\Project\GUI Group Project\WpfApp1\WpfApp1\DB\Users.db";
        //private readonly string _path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DB", "Users.db");

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite($"Data Source={_path}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("UserTable");
            modelBuilder.Entity<DoctorC>().ToTable("DoctorTable");
            modelBuilder.Entity<Patient>().ToTable("PatientTable");
            modelBuilder.Entity<DoctorReport>().ToTable("ReportTable");
        }

    }
}
