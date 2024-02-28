using BusinessObject.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class OrderDetail : BaseEntity
    {
        public Guid OrderDetailID { get; set; }
        public int Quantity { get; set; }
        public float Amount { get; set; }
        public Guid? SubscriptionId { get; set; }
        public SubscriptionPackage SubscriptionPackage { get; set; }
        public Guid? OrderID { get; set; }
        public Order Order { get; set; }
    }
}
