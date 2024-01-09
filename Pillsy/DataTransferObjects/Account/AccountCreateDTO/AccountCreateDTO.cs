using Pillsy.Enum.Account;
using System.Text.Json.Serialization;

namespace Pillsy.DataTransferObjects.Account.AccountCreateDTO
{
    public class AccountCreateDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AccountRole Role { get; set; }
    }
}
