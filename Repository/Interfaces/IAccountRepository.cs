using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAccounts();
        Task<Account> GetByEmailAndPassword(string email, string password);
        Task<Account> GetById (Guid id);
        Task<Account> AddNew(Account account);
        Task<Account> GetByEmail(string email);
        Task<bool> UpdateAccount(Account account);
        
        Task<Account> GetAccountByAccountIdAndPassword(Guid accountId, string password);
        Task<Account> GetAdminAccount();
    }
}
