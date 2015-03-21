using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CaleBlog.Domain.Entities;

namespace CaleBlog.Domain.Abstract
{
    public interface IPostsRepository
    {
        IEnumerable<Post> Posts { get; }
    }
}
