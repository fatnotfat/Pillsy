namespace Pillsy.DataTransferObjects.Prescription.PrescriptionCreateDto
{
    public class Metadata
    {
        public string? User_name { get; set; }
        public int? Age { get; set; }
        public int? Gender { get; set; }
        public string? Doctor_name { get; set; }
        public string? Hospital_name { get; set; }
        public string? Address { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Modified_at { get; set; }
        public string? Pathological { get; set; }
        public string? Note { get; set; }

    }
}
