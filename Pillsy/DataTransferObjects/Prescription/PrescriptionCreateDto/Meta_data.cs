using Pillsy.Enum.Patient;

namespace Pillsy.DataTransferObjects.Prescription.PrescriptionCreateDto
{
    public class Meta_data
    {
        public Guid User_id { get; set; }
        public string? Schema_version { get; set; }
        public string? User_name { get; set; }
        public string? Age { get; set; }
        public string? Gender { get; set; }
        public string? Doctor_name { get; set; }
        public string? Hospital_name { get; set; }
        public string? Address { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Modified_at { get; set; }
        public string? Pathological { get; set; }
        public string? Note { get; set; }

    }
}
