namespace Pillsy.DataTransferObjects.Prescription.PrescriptionUploadImageDto
{
    public class PrescriptionUploadImageDto
    {
        public Guid? User_Id { get; set; }
        public Guid? Prescription_Id { get; set; }
        public byte[]? ImageBase64 { get; set; }
    }
}
