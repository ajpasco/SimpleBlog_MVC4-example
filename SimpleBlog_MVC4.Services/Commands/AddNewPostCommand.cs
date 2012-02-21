using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBlog_MVC4.Services.Commands
{
    public class AddNewPostCommand: ICommand
    {
        public string Title { get; set; }
        public string Entry { get; set; }
    }
}
