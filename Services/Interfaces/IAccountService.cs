using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAllAccounts();
        Task<Account> GetAccountById(Guid id);
        Task<Account> GetAccountByEmailAndPassword(string email, string password);
        Task<Account> AddNewAccount(Account account);
        Task<Account> GetAccountByEmail(string email);
        Task<bool> UpdateAccount(Account account);
        Task<Account> GetAccountByAccountIdAndPassword(Guid accountId, string password);

    }
}
