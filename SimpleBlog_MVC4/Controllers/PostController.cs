using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SimpleBlog_MVC4.Domain.Entities;
using SimpleBlog_MVC4.Services;
using SimpleBlog_MVC4.Services.Commands;
using SimpleBlog_MVC4.Services.Queries;

namespace SimpleBlog_MVC4.Controllers
{
    public class PostController : ApiController
    {
        private readonly ICommandInvoker _commandInvoker;
        private readonly IPostReadQueries _postReadQueries;

        public PostController(ICommandInvoker commandInvoker, IPostReadQueries postReadQueries)
        {
            _commandInvoker = commandInvoker;
            _postReadQueries = postReadQueries;
        }

        public IQueryable<Post> GetAll()
        {
            return _postReadQueries.GetAll().AsQueryable();
        } 

        public Post Get(string id)
        {
            var post = _postReadQueries.GetById(id);

            if (post == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return post;
        }

        public HttpResponseMessage<Post> PostBlogPost(Post post)
        {
            var postExist = _postReadQueries.GetByTitle(post.Title);

            if (postExist == null)
            {
                _commandInvoker.Execute(new AddNewPostCommand()
                                            {
                                                Entry = post.Entry,
                                                Title = post.Title
                                            });

                var addedPost = _postReadQueries.GetByTitle(post.Title);
                var response = new HttpResponseMessage<Post>(addedPost, HttpStatusCode.Created);

                var uri = Url.Route(null, new { id = addedPost.Id });
                response.Headers.Location = new Uri(Request.RequestUri, uri);

                return response;
            }

            return new HttpResponseMessage<Post>(postExist, HttpStatusCode.Found);
        }

        public void PutPost(string id, Post post)
        {
            var postExist = _postReadQueries.GetById(post.Id);

            if (postExist == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);    
            }

            _commandInvoker.Execute(new UpdatePostCommand()
                    {
                        Entry = post.Entry,
                        Title = post.Title,
                        Id = post.Id
                    });
        }

        public HttpResponseMessage DeletePost(Post post)
        {
            var postExist = _postReadQueries.GetById(post.Id);

            if (postExist == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }

            _commandInvoker.Execute(new AddNewPostCommand()
            {
                Entry = post.Entry,
                Title = post.Title
            });

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
