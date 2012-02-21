using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleBlog_MVC4.Services.Repostory;

namespace SimpleBlog_MVC4.UnitTests.Helpers
{
    public class InMemRepository<T>: IRepository<T>
    {
        private readonly IList<T> _inMemList;
 
        public InMemRepository()
        {
            _inMemList = new List<T>();
        }

        public IQueryable<T> Get()
        {
            return _inMemList.AsQueryable();
        }

        public void Add(T entity)
        {
            _inMemList.Add(entity);
        }

        public void Delete(T entity)
        {
            _inMemList.Remove(entity);
        }
    }
}
