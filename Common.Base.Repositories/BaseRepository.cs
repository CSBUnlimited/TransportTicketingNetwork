using Common.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Common.Base.Repositories
{
    public abstract class BaseRepository : IRepository
    {
        protected virtual DbContext DbContext { get; }

        protected BaseRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
