using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaleBlog.Domain.Entities
{
    public class Post
    {
        public int PostID { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }
    }
}
