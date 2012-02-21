using Ninject;

namespace SimpleBlog_MVC4.Services.Infrastructure
{
    public interface IDependencyContainer
    {
        object Get<T>();
    }

    public class DependencyContainer : IDependencyContainer
    {
        private readonly IKernel _kernel;

        public DependencyContainer(IKernel kernel)
        {
            _kernel = kernel;
        }

        public object Get<T>()
        {
            return _kernel.Get<T>();
        }
    }
}