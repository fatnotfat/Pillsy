namespace Pillsy.DataTransferObjects.Prescription.UploadPredictInforPrescriptionDto
{
    public class ReturnPredictInforPrescriptionDto
    {
        public PrescriptionCreateDto.PrescriptionCreateDto PrescriptionCreateDto { get; set; }
        public BusinessObject.Prescription Prescription { get; set; }
    }
}
