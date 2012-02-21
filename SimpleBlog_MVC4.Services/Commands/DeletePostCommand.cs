using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBlog_MVC4.Services.Commands
{
    public class DeletePostCommand: ICommand
    {
        public string Id { get; set; }
    }
}
