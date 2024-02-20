using Newtonsoft.Json.Linq;

namespace Pillsy.DataTransferObjects.Prescription.PrescriptionRequestOCRInfoDto
{
    public class PrescriptionRequestOCRInfoDto
    {
        public string? Data {  get; set; } 
        public Guid? User_Id { get; set; }
        public Guid? Prescription_Id { get; set; }
    }
}
