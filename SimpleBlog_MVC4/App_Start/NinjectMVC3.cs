using Raven.Client;
using SimpleBlog_MVC4.Infrastructure;
using SimpleBlog_MVC4.Services;
using SimpleBlog_MVC4.Services.CommandHandlers;
using SimpleBlog_MVC4.Services.Commands;
using SimpleBlog_MVC4.Services.Infrastructure;
using SimpleBlog_MVC4.Services.Queries;
using SimpleBlog_MVC4.Services.Repostory;

[assembly: WebActivator.PreApplicationStartMethod(typeof(SimpleBlog_MVC4.App_Start.NinjectMVC3), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(SimpleBlog_MVC4.App_Start.NinjectMVC3), "Stop")]

namespace SimpleBlog_MVC4.App_Start
{
    using System.Reflection;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Mvc;

    public static class NinjectMVC3 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestModule));
            DynamicModuleUtility.RegisterModule(typeof(HttpApplicationInitializationModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IDocumentSession>().ToMethod(c =>
                                                         {
                                                             return DataDocumentStore.Instance.OpenSession();
                                                         })
                .InRequestScope();

            kernel.Bind<ICommandInvoker>().To<CommandInvoker>();
            kernel.Bind<ICommandHandler<AddNewPostCommand>>().To<AddNewPostCommandHandler>();
            kernel.Bind<ICommandHandler<UpdatePostCommand>>().To<UpdatePostCommandHandler>();
            kernel.Bind<IPostReadQueries>().To<PostReadQueries>();
            kernel.Bind(typeof(IRepository<>)).To(typeof(RavenRepository<>));
            kernel.Bind<IDependencyContainer>().To<DependencyContainer>();
            kernel.Bind<IKernel>().ToSelf();
        }        
    }
}
