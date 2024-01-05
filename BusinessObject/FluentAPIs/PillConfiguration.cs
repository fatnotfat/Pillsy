using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.FluentAPIs
{
    public class PillConfiguration : IEntityTypeConfiguration<Pill>
    {
        public void Configure(EntityTypeBuilder<Pill> builder)
        {
            builder.ToTable("Pill");
            builder.HasKey(x => x.PillId);
            builder.Property(x => x.PillName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.PillDescription).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Frequency).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.Period).IsRequired();
            builder.Property(x => x.Unit).IsRequired();
            builder.Property(x => x.Status).IsRequired();


            builder.HasOne<Schedule>(x => x.Schedule);

        }
    }
}
