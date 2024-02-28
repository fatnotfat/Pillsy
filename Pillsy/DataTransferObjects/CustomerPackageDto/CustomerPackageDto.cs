using BusinessObject;

namespace Pillsy.DataTransferObjects.CustomerPackageDto
{
    public class CustomerPackageDto
    {
        public string CustomerPackageName { get; set; }
        public int Status { get; set; }
        public string NumberScan { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public int AllowPillHistory { get; set; }
        public Guid PatientId { get; set; }
        public Guid SubcriptionPackageId { get; set; }
    }
}
