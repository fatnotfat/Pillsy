using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.FluentAPIs
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetail");
            builder.HasKey(x => x.OrderDetailID);
            builder.Property(x => x.OrderID).IsRequired();
            builder.Property(x => x.SubscriptionId).IsRequired();
            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.Quantity).IsRequired();
        }
    }
}
