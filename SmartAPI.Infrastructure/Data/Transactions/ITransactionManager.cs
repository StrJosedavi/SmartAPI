namespace SmartAPI.Infrastructure.Data.Transactions
{
    public interface ITransactionManager
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
