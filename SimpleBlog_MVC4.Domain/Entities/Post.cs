using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBlog_MVC4.Domain.Entities
{
    public class Post
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Entry { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
