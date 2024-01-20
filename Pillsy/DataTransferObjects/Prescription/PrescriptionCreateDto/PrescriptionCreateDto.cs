using Pillsy.DataTransferObjects.Patient.PatientDetailDto;
using Pillsy.DataTransferObjects.Prescription.PrescriptionCreateDto;


namespace Pillsy.DataTransferObjects.Prescription.PrescriptionCreateDto
{
    public class PrescriptionCreateDto
    {
        public Userdata? Userdata { get; set; }
        public Metadata? Metadata { get; set; }
    }
}
