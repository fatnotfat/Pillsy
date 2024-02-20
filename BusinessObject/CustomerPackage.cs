using BusinessObject.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class CustomerPackage : BaseEntity
    {
        public Guid CustomerPackageId { get; set; }
        public string CustomerPackageName { get; set;}
        public int Status { get; set;}
        public string NumberScan { get; set;}
        public DateTime? DateStart { get; set;}
        public DateTime? DateEnd { get; set;}
        public int AllowPillHistory { get; set;}
        public Guid PatientId { get; set;}
        public Patient Patient { get; set;}
        public Guid SubcriptionPackageId { get; set;}
        public SubscriptionPackage SubscriptionPackage { get; set;}
    }
}
