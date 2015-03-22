using System.Collections.Generic;

using CaleBlog.Domain.Abstract;
using CaleBlog.Domain.Entities;

namespace CaleBlog.Domain.Concrete
{
    public class EFPostRepository : IPostsRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Post> Posts
        {
            get { return context.Posts;  }
        }
    }
}
