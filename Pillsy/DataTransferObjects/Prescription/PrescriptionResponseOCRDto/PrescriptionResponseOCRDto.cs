namespace Pillsy.DataTransferObjects.Prescription.PrescriptionResponseOCRDto
{
    public class PrescriptionResponseOCRDto
    {
        public int? Status { get; set; }
        public Guid? User_Id { get; set; }
        public Guid? Prescription_Id { get; set; }
        public string? Data { get; set; }
        public string? Image { get; set; }
        public string? Error { get; set; }
    }
}
