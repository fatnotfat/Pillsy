﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class PillsyDBContext : DbContext
    {
        public PillsyDBContext()
        {

        }

        public PillsyDBContext(DbContextOptions<PillsyDBContext> opt) : base(opt)
        {

        }

        public virtual DbSet<Patient>? Patients { get; set; }
        public virtual DbSet<Doctor>? Doctors { get; set; }
        public virtual DbSet<Appointment>? Appointments { get; set; }
        public virtual DbSet<Prescription>? Prescriptions { get; set; }
        public virtual DbSet<Account>? Accounts { get; set; }
        public virtual DbSet<Payment>? Payments { get; set; }
        public virtual DbSet<Pill>? Pills { get; set; }
        public virtual DbSet<Schedule>? Schedules { get; set; }
        public virtual DbSet<SubscriptionPackage>? SubscriptionPackages { get; set; }
        public virtual DbSet<TransactionHistory>? TransactionHistory { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetConnectionString());
        }

#if DEBUG
        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json", true, true)
                .Build();
            return config["ConnectionStrings:DB"]!;
        }
#else
        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            return config["ConnectionStrings:DB"]!;
        }
#endif

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Add new data Account and Patient
            var accountId1 = Guid.NewGuid();
            var accountId2 = Guid.NewGuid();
            var accountId3 = Guid.NewGuid();

            var patientId1 = Guid.NewGuid();
            var doctorId1 = Guid.NewGuid(); 

            var paymentId1 = Guid.NewGuid();
            var paymentId2 = Guid.NewGuid();

            var scheduleId1 = Guid.NewGuid();
            
            var prescriptionId1 = Guid.NewGuid();

            var pillId1 = Guid.NewGuid();
            var pillId2 = Guid.NewGuid();
            var pillId3 = Guid.NewGuid();



            builder.Entity<Account>().HasData(
                new Account
                {
                    AccountId = accountId1,
                    Email = "nguyenphat2711@gmail.com",
                    Password = "@@admin@@",
                    Role = 0,
                    Status = 1,
                    CreatedBy = null,
                    CreatedDate = DateTime.UtcNow,
                    LastModifiedDate = DateTime.UtcNow,
                    ModifiedBy = null
                },
                new Account
                {
                    AccountId = accountId2,
                    Email = "dungnvse160223@fpt.edu.vn",
                    Password = "@@patient@@",
                    Role = 2,
                    Status = 1,
                    CreatedBy = null,
                    CreatedDate = DateTime.UtcNow,
                    LastModifiedDate = DateTime.UtcNow,
                    ModifiedBy = null
                },
                new Account
                {
                    AccountId = accountId3,
                    Email = "khoatruong2509@fpt.edu.vn",
                    Password = "@@doctor@@",
                    Role = 1,
                    Status = 1,
                    CreatedBy = null,
                    CreatedDate = DateTime.UtcNow,
                    LastModifiedDate = DateTime.UtcNow,
                    ModifiedBy = null
                });
            builder.Entity<Payment>().HasData(new Payment
            {
                PaymentId = paymentId1,
                PaymentType = "Momo",
                CreatedBy = null,
                CreatedDate = DateTime.UtcNow,
                LastModifiedDate = DateTime.UtcNow,
                ModifiedBy= null
            });
            builder.Entity<Doctor>().HasData(new Doctor
            {
                DoctorID = doctorId1,
                FirstName = "Khoa",
                LastName = "Truong",
                Specialty = "Khoa noi",
                PhoneNumber = "0987654321",
                AccountId = accountId3,
                CreatedBy = accountId3,
                CreatedDate = DateTime.UtcNow,
                LastModifiedDate = DateTime.UtcNow,
                ModifiedBy = accountId3
            });

            builder.Entity<Patient>().HasData(new Patient
            {
                PatientID = patientId1,
                FirstName = "Dung",
                LastName = "Nguyen",
                DateOfBirth = DateTime.Parse("2002-09-30"),
                Gender = 0,
                PhoneNumber = "0123456789",
                AccountId = accountId2,
                PaymentId = paymentId1,
                Address = "Bac Ninh",
                CreatedBy = accountId2,
                CreatedDate = DateTime.UtcNow,
                LastModifiedDate = DateTime.UtcNow,
                ModifiedBy= accountId2
            });

            builder.Entity<Schedule>().HasData(new Schedule
            {
                ScheduleId = scheduleId1,
                DateStart = DateTime.UtcNow,
                DateEnd = DateTime.Parse("2024-01-24"),
                Notes = "Dung 3 lieu, moi ngay 1 lieu",
                Status = 1,
                CreatedBy = accountId2,
                CreatedDate = DateTime.UtcNow,
                LastModifiedDate = DateTime.UtcNow,
                ModifiedBy = accountId2
            });

            builder.Entity<Prescription>().HasData(new Prescription
            {
                PrescriptionID = prescriptionId1,
                PatientID = patientId1,
                DoctorID = doctorId1,
                ExaminationDate = DateTime.Parse("2024-01-17"),
                Diagnosis = "viem da day",
                Status = 1,
                Image = "test",
                Index = 1,
                CreatedBy = accountId2,
                CreatedDate = DateTime.UtcNow,
                LastModifiedDate = DateTime.UtcNow,
                ModifiedBy = accountId2
            });

            builder.Entity<Pill>().HasData(new Pill
            {
                PillId = pillId1,
                PillName = "Nexium mup",
                PillDescription = "1 ngay uong 1 vien 30 phut sau khi an",
                DosagePerDay = 1,
                QuantityPerDose = 1,
                Period = "ngay",
                Status = 1,
                Unit = "vien",
                PrescriptionId = prescriptionId1,
                ScheduleId = scheduleId1,
                Morning = 1,
                Quantity = 30,
                Index = 1,
                CreatedBy = accountId2,
                CreatedDate = DateTime.UtcNow,
                LastModifiedDate = DateTime.UtcNow,
                ModifiedBy = accountId2
            });

            builder.Entity<Pill>().HasData(new Pill
            {
                PillId = pillId2,
                PillName = "Amoxycilin",
                PillDescription = "1 ngay uong 2 vien chia lam 2 lan(sang, toi - sau khi an)",
                DosagePerDay = 2,
                QuantityPerDose = 1,
                Period = "ngay",
                Status = 1,
                Unit = "vien",
                PrescriptionId = prescriptionId1,
                ScheduleId = scheduleId1,
                Morning = 1,
                Evening = 1,
                Quantity = 20,
                Index = 1,
                CreatedBy = accountId2,
                CreatedDate = DateTime.UtcNow,
                LastModifiedDate = DateTime.UtcNow,
                ModifiedBy = accountId2
            });



            //Take all configurations of entities from Infrastructures.FluentAPIs
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
