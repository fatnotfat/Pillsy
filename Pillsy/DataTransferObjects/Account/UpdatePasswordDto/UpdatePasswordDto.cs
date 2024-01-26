namespace Pillsy.DataTransferObjects.Account.UpdatePasswordDto
{
    public class UpdatePasswordDto
    {
        public Guid AccountId { get; set; }
        public string Password { get; set; }
    }
}
