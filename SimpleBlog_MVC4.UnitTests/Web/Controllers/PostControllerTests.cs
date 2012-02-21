using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using NUnit.Framework;
using SimpleBlog_MVC4.Controllers;
using SimpleBlog_MVC4.Domain.Entities;
using SimpleBlog_MVC4.Services;
using SimpleBlog_MVC4.UnitTests.Helpers;

namespace SimpleBlog_MVC4.UnitTests.Web.Controllers
{
    [TestFixture]
    public class PostControllerTests
    {
        private Mock<InMemRepository<Post>> _postRepository;
        private ICommandInvoker _commandInvoker;

        [SetUp]
        public void Setup()
        {
            _postRepository = new Mock<InMemRepository<Post>>();

            _postRepository.Setup(x => x.Get()).Returns(TestData.Posts.AsQueryable());
            //_commandInvoker = new CommandInvoker()
        }

        [Test]
        public void GetAll_Should_Return_All_Blog_Posts_When_Requested()
        {
            //arrange
            //var postController = new PostController()
        }
    }
}
