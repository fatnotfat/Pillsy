using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.FluentAPIs
{
    public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.ToTable("Prescription");
            builder.HasKey(x => x.PrescriptionID);
            builder.Property(x => x.Diagnosis).HasMaxLength(255).IsRequired();
            builder.Property(x => x.ExaminationDate).IsRequired();
            builder.Property(x => x.DoctorID).IsRequired();
            builder.Property(x => x.PatientID).IsRequired();
            builder.Property(x => x.Status).IsRequired();

            builder.HasMany(x => x.Pills)
                .WithOne(x => x.Prescription)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
