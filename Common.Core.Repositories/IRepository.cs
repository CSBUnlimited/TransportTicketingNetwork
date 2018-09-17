namespace Common.Core.Repositories
{
    public interface IRepository<TContext> where TContext : class
    {
        TContext DbContext { set; }
    }
}
