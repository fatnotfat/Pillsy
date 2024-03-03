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
            builder.HasKey(x => x.SubscriptionId);
            builder.Property(x => x.PackageType).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Period).IsRequired();
            builder.Property(x => x.UnitPrice).IsRequired();
            builder.Property(x => x.CurrencyUnit).IsRequired();
            builder.Property(x => x.Status).IsRequired();

            builder.HasMany(x => x.CustomerPackages)
               .WithOne(x => x.SubscriptionPackage)
               .HasForeignKey(x => x.SubcriptionPackageId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.OrderDetails)
                .WithOne(x => x.SubscriptionPackage)
                .HasForeignKey(x => x.SubscriptionId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.TransactionHistories)
                .WithOne(x => x.SubscriptionPackage)
                .HasForeignKey(x => x.PackageId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
