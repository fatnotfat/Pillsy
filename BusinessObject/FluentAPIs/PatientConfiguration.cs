using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.FluentAPIs
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patient");
            builder.HasKey(x => x.PatientID);
            builder.Property(x => x.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.DateOfBirth).IsRequired();
            builder.Property(x => x.Gender).IsRequired();
            builder.Property(x => x.PhoneNumber).IsRequired();
            builder.Property(x => x.Address).HasMaxLength(255).IsRequired();
            builder.HasIndex(x => x.PhoneNumber).IsUnique();

            builder.HasMany(x => x.Appointments)
                .WithOne(x => x.Patient)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.Prescriptions)
               .WithOne(x => x.Patient)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Payment)
               .WithMany(x => x.Patients)
               .OnDelete(DeleteBehavior.NoAction);

            //builder.HasOne<SubscriptionPackage>(x => x.SubscriptionPackage);

            builder.HasOne<Account>(x => x.Account);

        }
    }
}
