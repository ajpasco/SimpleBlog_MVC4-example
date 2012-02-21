using System.Linq;

namespace SimpleBlog_MVC4.Data.Repository
{
    public interface IRepository<T>
    {
        IQueryable<T> Get();
        T GetById(int id);
        void Update(T entity);
        void Add(T entity);
        void Delete(T entity);
    }
}
