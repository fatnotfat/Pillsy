namespace Pillsy.DataTransferObjects.Patient.PatientDetailDto
{
    public class Medication
    {
        public string? Name { get; set; }
        public int? Dosage_per_day { get; set; }
        public int? Quantity_per_dose { get; set; }
        public int? Total_quantity { get; set; }
        public string? Unit { get; set; }
        public Frequency? Frequency { get; set; }
        public DateTime? Start_date { get; set; }
        public DateTime? End_date { get; set; }
    }
}
