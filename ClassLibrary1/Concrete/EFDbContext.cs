using System.Data.Entity;

using CaleBlog.Domain.Entities;

namespace CaleBlog.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
    }
}
