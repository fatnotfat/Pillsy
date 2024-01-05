using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.FluentAPIs
{
    public class SubscriptionPackageConfiguration : IEntityTypeConfiguration<SubscriptionPackage>
    {
        public void Configure(EntityTypeBuilder<SubscriptionPackage> builder)
        {
            builder.ToTable("SubscriptionPackage");
            builder.HasKey(x => x.PackageId);
            builder.Property(x => x.PackageType).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Period).IsRequired();
            builder.Property(x => x.UnitPrice).IsRequired();
            builder.Property(x => x.CurrencyUnit).IsRequired();
            builder.Property(x => x.Status).IsRequired();


        }
    }
}
