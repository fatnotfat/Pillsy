using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        private readonly Dictionary<string, object> _repositoryDictionary;
        private IDbContextTransaction? transaction;

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
            _repositoryDictionary = new Dictionary<string, object>();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (transaction != null)
                throw new InvalidOperationException("Transaction has already been started.");

            transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                if (transaction == null)
                    throw new InvalidOperationException("Transaction has not been started.");

                await transaction.CommitAsync(cancellationToken);
            }
            catch
            {
                await RollbackTransactionAsync();
                throw;
            }
        }

        public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (transaction == null)
                throw new InvalidOperationException("Transaction has not been started.");

            await transaction.RollbackAsync(cancellationToken);
        }


        #region Destructor
        private bool isDisposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (isDisposed)
                return;

            if (disposing)
            {
                _dbContext.Dispose();
            }

            isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
        #endregion Destructor
    }
}
