namespace Pillsy.DataTransferObjects.UpdateTransactionHistoryDto
{
    public class UpdateTransactionHistoryDto
    {
        public Guid TransactionHistoryId { get; set; }
        public bool ISAllowed { get; set; }
    }
}
