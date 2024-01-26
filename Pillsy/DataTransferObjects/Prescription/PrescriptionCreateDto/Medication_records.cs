namespace Pillsy.DataTransferObjects.Prescription.PrescriptionCreateDto
{
    public class Medication_records
    {
        public Guid Record_id { get; set; }
        public string? Name { get; set; }
        public int? Dosage_per_day { get; set; }
        public int? Quantity_per_dose { get; set; }
        public int? Total_quantity { get; set; }
        public string? Unit { get; set; }
        public int? Frequency_morning { get; set; }
        public int? Frequency_afternoon { get; set; }
        public int? Frequency_evening { get; set; }
        public DateTime? Start_date { get; set; }
        public DateTime? End_date { get; set; }
    }
}
