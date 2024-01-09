using Pillsy.DataTransferObjects.Account.AccountCreateDTO;
using Pillsy.Enum.Patient;
using System.Text.Json.Serialization;

namespace Pillsy.DataTransferObjects.Patient.PatientDTO
{
    public class PatientDTO : AccountCreateDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PatientGender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
