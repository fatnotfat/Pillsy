using Pillsy.DataTransferObjects.Account.AccountCreateDTO;
using Pillsy.Enum.Patient;
using System.Text.Json.Serialization;

namespace Pillsy.DataTransferObjects.Patient.PatientCreateDTO
{
    public class PatientCreateDTO : AccountCreateDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public PatientGender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public Guid? PaymentId { get; set; }
    }
}
