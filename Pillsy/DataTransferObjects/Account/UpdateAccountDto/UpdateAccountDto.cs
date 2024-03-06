namespace Pillsy.DataTransferObjects.Account.UpdateAccountDto
{
    public class UpdateAccountDto
    {
        public Guid AccountId { get; set; }
        public int? Role {  get; set; }
        public int? Status { get; set; }
    }
}
