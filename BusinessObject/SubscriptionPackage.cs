using BusinessObject.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class SubscriptionPackage : BaseEntity
    {
        public Guid PackageId { get; set; }
        public string PackageType { get; set; }
        public string Period { get; set; }
        public float UnitPrice { get; set; }
        public string CurrencyUnit { get; set; }
        public int Status { get; set; }
        public List<CustomerPackage> CustomerPackages { get; set; }
    }
}
