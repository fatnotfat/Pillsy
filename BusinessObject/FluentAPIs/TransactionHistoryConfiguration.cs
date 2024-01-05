using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.FluentAPIs
{
    public class TransactionHistoryConfiguration : IEntityTypeConfiguration<TransactionHistory>
    {
        public void Configure(EntityTypeBuilder<TransactionHistory> builder)
        {
            builder.ToTable("TransactionHistory");
            builder.HasKey(x => x.TransactionId);
            builder.Property(x => x.Description).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Status).IsRequired();


            builder.HasOne<Patient>(x => x.Patient);
            builder.HasOne<SubscriptionPackage>(x => x.SubscriptionPackage);
            builder.HasOne<Payment>(x => x.Payment);
        }
    }
}
