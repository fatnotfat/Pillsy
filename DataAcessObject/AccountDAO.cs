using BusinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessObject
{
    public class AccountDAO
    {

        private static AccountDAO instance = null;

        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountDAO();
                }
                return instance;
            }
        }


        public async Task<IEnumerable<Account>> GetAccounts()
        {
            var _context = new PillsyDBContext();
            return await _context.Accounts.ToListAsync();
        }

        public async Task<Account> GetAccountByEmailAndPassword(string email, string password)
        {
            var _context = new PillsyDBContext();
            return await _context.Accounts.FirstOrDefaultAsync(a => a.Email.Equals(email.Trim()) && a.Password.Equals(password.Trim()));
        }

        public async Task<Account> GetAccountByEmail(string email)
        {
            var _context = new PillsyDBContext();
            return await _context.Accounts.FirstOrDefaultAsync(a => a.Email.Equals(email.Trim()));
        }

        public async Task<Account> GetAccountById(Guid accountId)
        {
            var _context = new PillsyDBContext();
            return await _context.Accounts.FirstOrDefaultAsync(a => a.AccountId.Equals(accountId));
        }

        public async Task<Account> Add(Account account)
        {
            var _context = new PillsyDBContext();
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                account.CreatedBy = account.AccountId;
                account.CreatedDate = DateTime.Now;
                account.LastModifiedDate = DateTime.Now;
                account.ModifiedBy = account.AccountId;
                account.Status = 0;

                _context.Accounts.AddAsync(account);
                await _context.SaveChangesAsync();
                transaction.Commit();
                return account;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return null;
            }
        }
    }
}
