using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CaleBlog.Domain.Abstract;
using CaleBlog.Domain.Entities;

namespace CaleBlog.WebUI.Controllers
{
    public class PostController : Controller
    {
        private IPostsRepository repository;
        public int PageSize = 4;

        public PostController(IPostsRepository postRepository)
        {
            this.repository = postRepository;
        }

        public ViewResult List(int page = 1)
        {
            return View(repository.Posts.OrderBy(post => post.PostID).Skip((page - 1) * PageSize).Take(PageSize));
        }
    }
}