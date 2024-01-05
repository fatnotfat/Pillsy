using BusinessObject.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class TransactionHistory : BaseEntity
    {
        public Guid TransactionId { get; set; }
        public Guid PatientId { get; set; }
        public Guid PackageId { get; set; }
        public Guid PaymentId { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
        public Patient Patient { get; set; }
        public SubscriptionPackage SubscriptionPackage { get; set; }
        public Payment Payment { get; set; }
    }
}
