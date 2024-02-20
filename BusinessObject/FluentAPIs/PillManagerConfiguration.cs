using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.FluentAPIs
{
    public class PillManagerConfiguration : IEntityTypeConfiguration<PillManager>
    {
        public void Configure(EntityTypeBuilder<PillManager> builder)
        {
            builder.ToTable("PillManager");
            builder.HasKey(x => x.PillManagerId);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.TakenTime).IsRequired();

            builder.HasOne<Patient>(x => x.Patient);
            builder.HasMany(x => x.Pill)
               .WithOne(x => x.PillManager)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
