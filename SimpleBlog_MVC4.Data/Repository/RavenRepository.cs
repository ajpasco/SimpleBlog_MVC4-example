using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Client;

namespace SimpleBlog_MVC4.Data.Repository
{
    public class RavenRepository<T>: IRepository<T>
    {
        public RavenRepository(IDocumentSession session)
        {
            
        }

        public IQueryable<T> Get()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
