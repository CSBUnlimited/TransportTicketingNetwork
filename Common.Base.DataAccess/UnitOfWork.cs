using System.Threading.Tasks;
using Common.Core.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Common.Base.DataAccess
{
    public abstract class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        /// <summary>
        /// UnitOfWork - Constructor
        /// </summary>
        /// <param name="dbContext">DbContext</param>
        protected UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// To save changes to database, when complete process and data changes - Async
        /// </summary>
        /// <returns>Rows count affected</returns>
        public async Task<int> CompleteAsync() => await _dbContext.SaveChangesAsync();

        /// <summary>
        /// Creating transaction object to use - Async
        /// </summary>
        /// <returns>DbContextTransaction</returns>
        public async Task<IDbContextTransaction> BeginTransactionAsync() =>
            await _dbContext.Database.BeginTransactionAsync();
    }
}
