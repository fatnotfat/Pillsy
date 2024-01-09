using Microsoft.EntityFrameworkCore;
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

        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            return config["ConnectionStrings:DB"]!;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Add new data Account and Patient
            var accountId1 = Guid.NewGuid();
            var accountId2 = Guid.NewGuid();
            var accountId3 = Guid.NewGuid();

            var patientId1 = Guid.NewGuid();

            var paymentId1 = Guid.NewGuid();
            var paymentId2 = Guid.NewGuid();
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

            builder.Entity<Patient>().HasData(new Patient
            {
                PatientID = patientId1,
                FirstName = "Dung",
                LastName = "Nguyen",
                DateOfBirth = DateTime.Parse("2002-30-09"),
                Gender = 0,
                PaymentId = paymentId1,
                Address = "Bac Ninh",
                CreatedBy = accountId2,
                CreatedDate = DateTime.UtcNow,
                LastModifiedDate = DateTime.UtcNow,
                ModifiedBy= accountId2
            });

            //Take all configurations of entities from Infrastructures.FluentAPIs
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
