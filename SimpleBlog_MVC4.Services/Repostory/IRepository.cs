using System.Linq;

namespace SimpleBlog_MVC4.Services.Repostory
{
    public interface IRepository<T>
    {
        IQueryable<T> Get();
        void Add(T entity);
        void Delete(T entity);
    }
}
