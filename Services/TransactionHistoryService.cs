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
    public class TransactionHistoryService : ITransactionHistoryService
    {
        private readonly ITransactionHistoryRepository _transactionHistoryRepository;

        public TransactionHistoryService(ITransactionHistoryRepository transactionHistoryRepository)
        {
            _transactionHistoryRepository = transactionHistoryRepository;
        }

        public async Task<bool> AddNewTransactionHistory(TransactionHistory transactionHistory)
        {
            return await _transactionHistoryRepository.AddNewTransactionHistory(transactionHistory);
        }

        public async Task<IEnumerable<TransactionHistory>> GetAllTransactions()
        {
            return await _transactionHistoryRepository.GetAllTransactions();
        }

        public async Task<IEnumerable<TransactionHistory>> GetAllTransactionsWithSuccessStatus()
        {
            return await _transactionHistoryRepository.GetAllTransactionsWithSuccessStatus();
        }

        public async Task<IEnumerable<TransactionHistory>> GetTransactionByPatientId(Guid patientId)
        {
            return await _transactionHistoryRepository.GetTransactionByPatientId(patientId);
        }

        public async Task<TransactionHistory> GetTransactionByTransactionId(Guid transactionID)
        {
            return await _transactionHistoryRepository.GetTransactionByTransactionId(transactionID);
        }

        public async Task<bool> UpdateTransactionHistory(TransactionHistory transactionHistory)
        {
            return await _transactionHistoryRepository.UpdateTransactionHistory(transactionHistory);
        }
    }
}
