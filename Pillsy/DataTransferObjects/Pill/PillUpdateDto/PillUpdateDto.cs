namespace Pillsy.DataTransferObjects.Pill.PillUpdateDto
{
    public class PillUpdateDto
    {
        public string PillName { get; set; }
        public string? PillDescription { get; set; }
        public int? DosagePerDay { get; set; }
        public int? Quantity { get; set; }
        public int? QuantityPerDose { get; set; }
        public string? Period { get; set; }
        public string? Unit { get; set; }
        public int? Morning { get; set; }
        public int? Afternoon { get; set; }
        public int? Evening { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
    }
}
