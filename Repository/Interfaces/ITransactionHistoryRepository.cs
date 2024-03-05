using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ITransactionHistoryRepository
    {
        public Task<IEnumerable<TransactionHistory>> GetAllTransactions();
        public Task<IEnumerable<TransactionHistory>> GetTransactionByPatientId(Guid patientId);
        public Task<TransactionHistory> GetTransactionByTransactionId(Guid transactionID);
        public Task<bool> UpdateTransactionHistory(TransactionHistory transactionHistory);
        public Task<bool> AddNewTransactionHistory(TransactionHistory transactionHistory);
        public Task<IEnumerable<TransactionHistory>> GetAllTransactionsWithSuccessStatus();


    }
}
