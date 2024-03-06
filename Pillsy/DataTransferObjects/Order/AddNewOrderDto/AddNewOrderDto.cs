using BusinessObject;

namespace Pillsy.DataTransferObjects.Order.AddNewOrderDto
{
    public class AddNewOrderDto
    {
        public double TotalPrice { get; set; }
        public int TotalItem { get; set; }
        public bool Status { get; set; }
        public int? OrderId_PayOS { get; set; }
        public Guid? PatientId { get; set; }
    }
}
