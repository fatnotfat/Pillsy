using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.FluentAPIs
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder.HasKey(x => x.OrderID);
            builder.Property(x => x.TotalPrice).IsRequired();
            builder.Property(x => x.TotalItem).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            //builder.Property(x => x.OrderId_PayOS).ValueGeneratedOnAdd();
            builder.HasMany(x => x.OrderDetails).WithOne(x => x.Order).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
