using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Ninject;
using Raven.Client;
using SimpleBlog_MVC4.Services.Infrastructure;

namespace SimpleBlog_MVC4.Services
{
    public class CommandInvoker : ICommandInvoker
    {
        private readonly IDependencyContainer _container;
        private readonly IDocumentSession _documentSession;

        public CommandInvoker(IDependencyContainer container, IDocumentSession documentSession)
        {
            _container = container;
            _documentSession = documentSession;
        }

        public void Execute<T>(T command)
        {
            var handler = _container.Get<ICommandHandler<T>>() as ICommandHandler<T>;

            handler.Handle(command);
            _documentSession.SaveChanges();
            
        }
    }
}
