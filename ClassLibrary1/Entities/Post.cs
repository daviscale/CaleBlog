using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaleBlog.Domain.Entities
{
    public class Post
    {
        public int PostID { get; set; }

        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Body { get; set; }
    }
}
