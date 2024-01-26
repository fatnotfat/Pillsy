namespace Pillsy.DataTransferObjects.Pill.PillCreateDto
{
    public class PillCreateDto
    {
        public Guid PillId { get; set; }
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
        public Guid ScheduleId { get; set; }

    }
}
