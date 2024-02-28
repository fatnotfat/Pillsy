using BusinessObject.Base;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Order : BaseEntity
    {
        public Guid OrderID { get; set; }
        public double TotalPrice { get; set; }
        public int TotalItem { get; set; }
        public bool Status { get; set; }
        public int? OrderId_PayOS { get; set; }
        public Guid? PatientId { get; set; }
        public Patient Patient { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    } 
}
