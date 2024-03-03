using BusinessObject;
using DataAcessObject;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class TransactionHistoryRepository : ITransactionHistoryRepository
    {
        public async Task<bool> AddNewTransactionHistory(TransactionHistory transactionHistory)
        {
            return await TransactionHistoryDAO.Instance.AddNewTransactionHistory(transactionHistory);
        }

        public async Task<IEnumerable<TransactionHistory>> GetAllTransactions()
        {
            return await TransactionHistoryDAO.Instance.GetAllTransactions();
        }

        public async Task<IEnumerable<TransactionHistory>> GetTransactionByPatientId(Guid patientId)
        {
            return await TransactionHistoryDAO.Instance.GetTransactionByPatientId(patientId);
        }

        public async Task<TransactionHistory> GetTransactionByTransactionId(Guid transactionID)
        {
            return await TransactionHistoryDAO.Instance.GetTransactionByTransactionId(transactionID);
        }

        public async Task<bool> UpdateTransactionHistory(TransactionHistory transactionHistory)
        {
            return await TransactionHistoryDAO.Instance.UpdateTransactionHistory(transactionHistory);
        }
    }
}
