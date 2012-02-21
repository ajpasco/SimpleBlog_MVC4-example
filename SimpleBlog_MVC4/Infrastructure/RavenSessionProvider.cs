using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Raven.Client;

namespace SimpleBlog_MVC4.Infrastructure
{
    public interface IDbSessionProvider
    {
        IDocumentSession GetSession();
    }

    public class RavenSessionProvider : IDbSessionProvider
    {
        public IDocumentSession GetSession()
        {
            return DataDocumentStore.Instance.OpenSession();
        }
    }
}