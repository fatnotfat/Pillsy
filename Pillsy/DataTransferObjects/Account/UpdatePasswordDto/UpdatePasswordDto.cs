namespace Pillsy.DataTransferObjects.Account.UpdatePasswordDto
{
    public class UpdatePasswordDto
    {
        public Guid AccountId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
