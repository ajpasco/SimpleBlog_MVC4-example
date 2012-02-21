using System;
using System.Linq;
using SimpleBlog_MVC4.Domain.Entities;
using SimpleBlog_MVC4.Services.Commands;
using SimpleBlog_MVC4.Services.Repostory;

namespace SimpleBlog_MVC4.Services.CommandHandlers
{
    public class DeletePostCommandHandler: ICommandHandler<DeletePostCommand>
    {
        private readonly IRepository<Post> _postRepository;

        public DeletePostCommandHandler(IRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }

        public void Handle(DeletePostCommand command)
        {
            var post = _postRepository.Get().SingleOrDefault(x => x.Id == command.Id);

            _postRepository.Delete(post);
        }
    }
}
