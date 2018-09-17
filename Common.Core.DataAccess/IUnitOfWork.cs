using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace Common.Core.DataAccess
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// To save changes to database, when complete process and data changes - Async
        /// </summary>
        /// <returns>Rows count affected</returns>
        Task<int> CompleteAsync();

        /// <summary>
        /// Creating transaction object to use - Async
        /// </summary>
        /// <returns>DbContextTransaction</returns>
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
