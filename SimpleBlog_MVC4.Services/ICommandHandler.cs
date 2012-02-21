namespace SimpleBlog_MVC4.Services
{
    public interface ICommandHandler<T>
    {
        void Handle(T command);
    }
}
