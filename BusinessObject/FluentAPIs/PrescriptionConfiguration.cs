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
            builder.Property(x => x.Diagnosis).HasMaxLength(255);
            builder.Property(x => x.ExaminationDate);
            builder.Property(x => x.DoctorID);
            builder.Property(x => x.PatientID);
            builder.Property(x => x.Status);

            builder.HasMany(x => x.Pills)
                .WithOne(x => x.Prescription)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
