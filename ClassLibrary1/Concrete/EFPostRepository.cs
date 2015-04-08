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

        public void SavePost(Post post)
        {
            if (post.PostID == 0)
            {
                context.Posts.Add(post);
            }
            else
            {
                Post dbEntry = context.Posts.Find(post.PostID);
                if (dbEntry != null)
                {
                    dbEntry.Title = post.Title;
                    dbEntry.Body = post.Body;
                }
            }
            context.SaveChanges();
        }

        public Post DeletePost(int postId)
        {
            Post dbEntry = context.Posts.Find(postId);
            if (dbEntry != null)
            {
                context.Posts.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
