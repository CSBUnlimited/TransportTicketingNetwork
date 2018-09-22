using Microsoft.EntityFrameworkCore.Storage;

namespace Common.Base.DataAccess
{
    public static class UnitOfWorkExtension
    {
        public static void CommitTransaction(this IDbContextTransaction dbContextTransaction)
        {
            dbContextTransaction.Commit();
        }

        public static void RollbackTransaction(this IDbContextTransaction dbContextTransaction)
        {
            dbContextTransaction.Rollback();
        }
    }
}
