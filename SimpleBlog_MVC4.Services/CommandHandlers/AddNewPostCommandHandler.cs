using System;
using SimpleBlog_MVC4.Domain.Entities;
using SimpleBlog_MVC4.Services.Commands;
using SimpleBlog_MVC4.Services.Repostory;

namespace SimpleBlog_MVC4.Services.CommandHandlers
{
    public class AddNewPostCommandHandler: ICommandHandler<AddNewPostCommand>
    {
        private readonly IRepository<Post> _postRepository;
 
        public AddNewPostCommandHandler(IRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }

        public void Handle(AddNewPostCommand command)
        {
            var post = new Post()
                {
                    Title = command.Title,
                    Entry = command.Entry,
                    CreateDate = DateTime.UtcNow
                };

            _postRepository.Add(post);
        }
    }
}
