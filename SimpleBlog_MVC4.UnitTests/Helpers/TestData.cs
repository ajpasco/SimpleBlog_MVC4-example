using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleBlog_MVC4.Domain.Entities;

namespace SimpleBlog_MVC4.UnitTests.Helpers
{
    public class TestData
    {
        public static IEnumerable<Post> Posts
        {
            get
            {
                var posts = new List<Post>
                    {
                        new Post() {Id = "posts-1", Title = "title 1", Entry = "entry-1"},
                        new Post() {Id = "posts-2", Title = "title 2", Entry = "entry-2"},
                        new Post() {Id = "posts-3", Title = "title 3", Entry = "entry-3"}
                    };

                return posts;
            }
        } 
    }
}
