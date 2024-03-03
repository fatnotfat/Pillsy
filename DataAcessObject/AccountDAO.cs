using BusinessObject;
using Microsoft.AspNetCore.Identity;
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


                await _context.Accounts.AddAsync(account);
                await _context.SaveChangesAsync();
                transaction.Commit();
                return account;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> UpdateAccountAsync(Account account)
        {
            var isSuccess = false;
            try
            {
                var _context = new PillsyDBContext();
                account.CreatedBy = account.AccountId;
                account.ModifiedBy = account.AccountId;
                account.LastModifiedDate = account.LastModifiedDate;
                _context.Entry(account).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                isSuccess = true;
            }
            catch (Exception)
            {
                throw;
            }
            return isSuccess;
        }

        public async Task<Account> GetAccountByIdAndPasswordAsync(Guid accountId, string oldPassword)
        {
            Account account = null;
            try
            {
                var _context = new PillsyDBContext();
                account = await _context.Accounts.FirstOrDefaultAsync(a => a.AccountId.Equals(accountId) && a.Password.Equals(oldPassword.Trim()));
            }
            catch (Exception)
            {
                throw;
            }
            return account;
        }

        public async Task<Account> GetAdminAsync()
        {
            Account account = null;
            try
            {
                var _context = new PillsyDBContext();
                account = await _context.Accounts.FirstOrDefaultAsync(a => a.Role == 0);
            }
            catch (Exception)
            {
                throw;
            }
            return account;
        }
    }
}
