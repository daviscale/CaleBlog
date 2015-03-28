using System.Collections.Generic;

using CaleBlog.Domain.Entities;

namespace CaleBlog.WebUI.Models
{
    public class PostListViewModel
    {
        public IEnumerable<Post> Posts { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}