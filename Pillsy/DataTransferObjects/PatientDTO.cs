using Pillsy.Enum.Patient;
using System.Text.Json.Serialization;

namespace Pillsy.DataTransferObjects
{
    public class PatientDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PatientGender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public Guid AccountId { get; set; }
    }
}
