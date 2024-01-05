using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.FluentAPIs
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable("Schedule");
            builder.HasKey(x => x.ScheduleId);
            builder.Property(x => x.DateStart).IsRequired();
            builder.Property(x => x.DateEnd).IsRequired();
            builder.Property(x => x.Notes).HasMaxLength(255);


        }
    }
}
