using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CaleBlog.Domain.Abstract;
using CaleBlog.Domain.Entities;
using CaleBlog.WebUI.Models;

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
            PostListViewModel model = new PostListViewModel
            {
                Posts = repository.Posts.OrderBy(post => post.PostID).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Posts.Count()
                }
            };
            return View(model);
        }

        public ViewResult View(int postId)
        {
            return ViewOrEditPost(postId);
        }

        public ViewResult Edit(int postId)
        {
            return ViewOrEditPost(postId);
        }

        private ViewResult ViewOrEditPost(int postId)
        {
            Post post = repository.Posts.FirstOrDefault(pst => pst.PostID == postId);
            return View(post);
        }

        [HttpPost]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                repository.SavePost(post);
                TempData["message"] = string.Format("{0} has been saved", post.Title);
                return RedirectToAction("List");
            }
            else
            {
                return View(post);
            }
        }

        public ViewResult Create()
        {
            return View("Create", new Post());
        }

        [HttpPost]
        public ActionResult Delete(int postId)
        {
            Post deletedPost = repository.DeletePost(postId);
            if (deletedPost != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedPost.Title);
            }
            return RedirectToAction("List");
        }
    }
}