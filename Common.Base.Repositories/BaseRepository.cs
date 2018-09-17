using Common.Core.Repositories;

namespace Common.Base.Repositories
{
    public abstract class BaseRepository<TContext> : IRepository<TContext> where TContext : class
    {
        public TContext DbContext { protected get; set; }
    }
}
