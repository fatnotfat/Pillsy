using Pillsy.DataTransferObjects.Prescription.PrescriptionCreateDto;


namespace Pillsy.DataTransferObjects.Prescription.PrescriptionCreateDto
{
    public class PrescriptionCreateDto
    {
        public string? Status {  get; set; }
        public User_data? Data { get; set; }
        public string? Error { get; set; }
    }
}
