using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleBlog_MVC4.Domain.Entities;
using SimpleBlog_MVC4.Services.Repostory;

namespace SimpleBlog_MVC4.Services.Queries
{
    public interface IPostReadQueries
    {
        IEnumerable<Post> GetAll();
        Post GetById(string id);
        Post GetByTitle(string title);
    }

    public class PostReadQueries : IPostReadQueries
    {
        private readonly IRepository<Post> _postRepostory;

        public PostReadQueries(IRepository<Post> postRepo)
        {
            _postRepostory = postRepo;
        }

        public IEnumerable<Post> GetAll()
        {
            return _postRepostory.Get().ToList();
        }

        public Post GetById(string id)
        {
            return _postRepostory.Get().SingleOrDefault(x => x.Id == id);
        }

        public Post GetByTitle(string title)
        {
            return _postRepostory.Get().SingleOrDefault(x => x.Title.ToLower() == title.ToLower());
        }
    }
}
