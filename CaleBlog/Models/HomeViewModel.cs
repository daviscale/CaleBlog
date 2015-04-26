using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using CaleBlog.Domain.Entities;

namespace CaleBlog.WebUI.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Post> RecentPosts { get; set; }
        public Post HomePost { get; set; }
    }
}