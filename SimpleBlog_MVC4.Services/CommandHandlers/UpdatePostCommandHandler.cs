using System;
using SimpleBlog_MVC4.Domain.Entities;
using SimpleBlog_MVC4.Services.Commands;
using SimpleBlog_MVC4.Services.Repostory;
using System.Linq;

namespace SimpleBlog_MVC4.Services.CommandHandlers
{
    public class UpdatePostCommandHandler: ICommandHandler<UpdatePostCommand>
    {
        private readonly IRepository<Post> _postRepository;
 
        public UpdatePostCommandHandler(IRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }

        public void Handle(UpdatePostCommand command)
        {
            var post = _postRepository.Get().SingleOrDefault(x=>x.Id == command.Id);

            if (post != null)
            {
                post.Entry = command.Entry;
                post.Title = command.Title;
                post.ModifiedDate = DateTime.UtcNow;
            }
        }
    }
}
