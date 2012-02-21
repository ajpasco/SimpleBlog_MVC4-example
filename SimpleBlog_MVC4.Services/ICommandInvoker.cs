namespace SimpleBlog_MVC4.Services
{
    public interface ICommandInvoker
    {
        void Execute<T>(T command);
    }
}
