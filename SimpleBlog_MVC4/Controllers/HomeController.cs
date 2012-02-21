using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleBlog_MVC4.Domain.Entities;
using SimpleBlog_MVC4.Services;
using SimpleBlog_MVC4.Services.Commands;
using SimpleBlog_MVC4.Services.Queries;

namespace SimpleBlog_MVC4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICommandInvoker _commandInvoker;
        private readonly IPostReadQueries _postReadQueries;

        public HomeController(ICommandInvoker commandInvoker, IPostReadQueries postReadQueries)
        {
            _commandInvoker = commandInvoker;
            _postReadQueries = postReadQueries;
        }

        public ActionResult Index()
        {
            //var post = new Post();
            //post.Title = "test";
            //post.Entry = "entry";

            //_commandInvoker.Execute(new AddNewPostCommand()
            //        {
            //            Entry = post.Entry,
            //            Title = post.Title
            //        });

            //var posts = _postReadQueries.GetAll();

            //var post = _postReadQueries.GetById("posts-1");

            _commandInvoker.Execute(new UpdatePostCommand()
                                        {
                                            Id = "posts-1",
                                            Title = "title changed",
                                            Entry = "entry changed"
                                        });

            var post = _postReadQueries.GetById("posts-1");

            return View();
        }
    }
}
