using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBlog_MVC4.Services.Commands
{
    public class UpdatePostCommand: ICommand
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Entry { get; set; }
    }
}
