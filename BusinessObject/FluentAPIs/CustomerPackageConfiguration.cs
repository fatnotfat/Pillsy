using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.FluentAPIs
{
    public class CustomerPackageConfiguration : IEntityTypeConfiguration<CustomerPackage>
    {
        public void Configure(EntityTypeBuilder<CustomerPackage> builder)
        {
            builder.ToTable("CustomerPackage");
            builder.HasKey(x => x.CustomerPackageId);
            builder.Property(x => x.CustomerPackageName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.NumberScan).IsRequired();
            builder.Property(x => x.AllowPillHistory).IsRequired();


        }
    }
}
