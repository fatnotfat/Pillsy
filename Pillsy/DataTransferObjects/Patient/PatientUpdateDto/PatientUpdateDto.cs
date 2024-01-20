using System.ComponentModel.DataAnnotations;

namespace Pillsy.DataTransferObjects.Patient.PatientUpdateDto
{
    public class PatientUpdateDto
    {
        [Required]
        public Guid PatientID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
    }
}
