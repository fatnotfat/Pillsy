namespace Pillsy.DataTransferObjects.Pill.PillCreateWithPrescriptionDto
{
    public class PillCreateWithPrescriptionDto
    {
        public string PillName { get; set; }
        public string? PillDescription { get; set; }
        public int? DosagePerDay { get; set; }
        public int? Quantity { get; set; }
        public int? QuantityPerDose { get; set; }
        public string? Period { get; set; }
        public string? Unit { get; set; }
        public int Morning { get; set; } = 0;
        public int Afternoon { get; set; } = 0;
        public int Evening { get; set; } = 0;
        public Guid PrescriptionId { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
    }
}
