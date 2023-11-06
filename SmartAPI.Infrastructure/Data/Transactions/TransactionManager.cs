using Microsoft.EntityFrameworkCore.Storage;

namespace SmartAPI.Infrastructure.Data.Transactions
{
    public class TransactionManager : ITransactionManager
    {
        private readonly ApplicationDbContext _context;
        private readonly ApplicationIdentityDbContext _identityContext;
        private IDbContextTransaction _transaction;

        public TransactionManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public TransactionManager(ApplicationIdentityDbContext context)
        {
            _identityContext = context;
        }

        public void BeginTransaction()
        {

            if (_identityContext == null)
                _transaction = _context.Database.BeginTransaction();
            else
                _transaction = _identityContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }
    }
}
