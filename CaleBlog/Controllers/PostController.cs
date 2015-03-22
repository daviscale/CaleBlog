using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CaleBlog.Domain.Abstract;
using CaleBlog.Domain.Entities;

namespace CaleBlog.Controllers
{
    public class PostController : Controller
    {
        private IPostsRepository repository;

        public PostController(IPostsRepository postRepository)
        {
            this.repository = postRepository;
        }

        public ViewResult List()
        {
            return View(repository.Posts);
        }
    }
}