using Pillsy.DataTransferObjects.Prescription.PrescriptionCreateDto;


namespace Pillsy.DataTransferObjects.Prescription.PrescriptionCreateDto
{
    public class PrescriptionCreateDto
    {
        public string? Status {  get; set; }
        public User_data? User_data { get; set; }
        public Metadata? Meta_data { get; set; }
        public string? Error { get; set; }
    }
}
