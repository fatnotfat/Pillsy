using BusinessObject.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Patient : BaseEntity
    {
        public Guid PatientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public Guid AccountId { get; set; }
        public Account Account { get; set; }
        public List<Appointment> Appointments { get; set; }
        public List<Prescription> Prescriptions { get; set; }
        public Guid PaymentId { get; set; }
        public Payment Payment { get; set; }
        //public Guid PackageId { get; set; }
        //public SubscriptionPackage SubscriptionPackage { get; set; }
    }
}
