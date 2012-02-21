using System;
using System.Linq;
using Raven.Client;

namespace SimpleBlog_MVC4.Services.Repostory
{
    public class RavenRepository<T>: IRepository<T>
    {
        private readonly IDocumentSession _documentSession;

        public RavenRepository(IDocumentSession documentSession)
        {
            _documentSession = documentSession;
        }

        public IQueryable<T> Get()
        {
            return _documentSession.Query<T>();
        }

        public void Add(T entity)
        {
            _documentSession.Store(entity);
        }

        public void Delete(T entity)
        {
            _documentSession.Delete(entity);
        }
    }
}
