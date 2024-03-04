namespace Pillsy.DataTransferObjects.Prescription.UploadPredictInforPrescriptionDto
{
    public class UploadPredictInforPrescriptionDto
    {
        public PrescriptionCreateDto.PrescriptionCreateDto PrescriptionCreateDto { get; set; }
        public BusinessObject.Prescription Prescription { get; set; }
    }
}
