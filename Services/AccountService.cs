using BusinessObject;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Account> AddNewAccount(Account account)
        {
            return await _accountRepository.AddNew(account);
        }

        public async Task<Account> GetAccountByAccountIdAndPassword(Guid accountId, string password)
        {
            return await _accountRepository.GetAccountByAccountIdAndPassword(accountId, password);
        }

        public async Task<Account> GetAccountByEmail(string email, string password)
        {
            var account = await _accountRepository.GetByEmail(email);
            if (account != null && account.Password.Equals(email.Trim())) return account;
            return null;
        }

        public async Task<Account> GetAccountByEmailAndPassword(string email, string password)
        {
            return await _accountRepository.GetByEmailAndPassword(email, password);
        }

        public async Task<Account> GetAccountById(Guid id)
        {
            return await _accountRepository.GetById(id);
        }

        public async Task<IEnumerable<Account>> GetAllAccounts()
        {
            return await _accountRepository.GetAccounts();
        }

        public async Task<bool> UpdateAccount(Account account)
        {
            return await _accountRepository.UpdateAccount(account);
        }
    }
}
