namespace Pillsy.DataTransferObjects.Patient.PatientDetailDto
{
    public class Medication_records
    {
        public Guid Record_id { get; set; }
        public List<Medication>? Medication { get; set; }
    }
}
