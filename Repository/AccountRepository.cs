using BusinessObject;
using DataAcessObject;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AccountRepository : IAccountRepository
    {
        private AccountDAO accountDAO;
        public AccountRepository()
        {
            accountDAO = new AccountDAO();
        }

        public async Task<Account> AddNew(Account account)
        {
            return await accountDAO.Add(account);
        }

        public async Task<Account> GetAccountByAccountIdAndPassword(Guid accountId, string password)
        {
            return await accountDAO.GetAccountByIdAndPasswordAsync(accountId, password);
        }

        public async Task<IEnumerable<Account>> GetAccounts()
        {
            return await accountDAO.GetAccounts();
        }

        public async Task<Account> GetByEmail(string email)
        {
            var account = await accountDAO.GetAccountByEmail(email);
            if(account != null)
            {
                return account;
            }
            return null;
        }

        public async Task<Account> GetByEmailAndPassword(string email, string password)
        {
            return await accountDAO.GetAccountByEmailAndPassword(email, password);
        }

        public async Task<Account> GetById(Guid id)
        {
            return await accountDAO.GetAccountById(id);
        }

        public async Task<bool> UpdateAccount(Account account)
        {
            return await accountDAO.UpdateAccountAsync(account);
        }
    }
}
