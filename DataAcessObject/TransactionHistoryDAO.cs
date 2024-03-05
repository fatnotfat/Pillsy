using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessObject
{
    public class TransactionHistoryDAO
    {
        private static TransactionHistoryDAO instance = null;


        public static TransactionHistoryDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TransactionHistoryDAO();
                }
                return instance;
            }
        }

        public async Task<IEnumerable<TransactionHistory>> GetAllTransactions()
        {
            var context = new PillsyDBContext();
            var transactions = await context.TransactionHistory!.Include(t => t.SubscriptionPackage).ToListAsync();
            return transactions;
        }

        public async Task<IEnumerable<TransactionHistory>> GetAllTransactionsWithSuccessStatus()
        {
            var context = new PillsyDBContext();
            var transactions = await context.TransactionHistory!.Include(t => t.SubscriptionPackage).Where(t => t.Status == 1).ToListAsync();
            return transactions;
        }
        public async Task<TransactionHistory> GetTransactionByTransactionId(Guid transactionID)
        {
            var context = new PillsyDBContext();
            var transaction = await context.TransactionHistory!.FirstOrDefaultAsync(x => x.TransactionId.Equals(transactionID));
            return transaction;
        }

        public async Task<IEnumerable<TransactionHistory>> GetTransactionByPatientId(Guid patientId)
        {
            var context = new PillsyDBContext();
            var transactions = await context.TransactionHistory!.Where(t => t.PatientId.Equals(patientId)).ToListAsync();
            return transactions;
        }

        public async Task<bool> AddNewTransactionHistory(TransactionHistory transactionHistory)
        {
            var context = new PillsyDBContext();
            var result = context.Add(transactionHistory);
            await context.SaveChangesAsync();
            if (result != null)
            {
                return true;
            }
            return false;
        }


        public async Task<bool> UpdateTransactionHistory(TransactionHistory transactionHistory)
        {
            var context = new PillsyDBContext();
            var result = context.Update(transactionHistory);
            await context.SaveChangesAsync();
            if (result != null)
            {
                return true;
            }
            return false;
        }
    }
}
