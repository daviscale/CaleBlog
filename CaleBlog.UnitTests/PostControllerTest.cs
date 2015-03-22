using System;
using System.Collections.Generic;
using System.Linq;

using CaleBlog.Domain.Abstract;
using CaleBlog.Domain.Entities;
using CaleBlog.WebUI.Controllers;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

namespace CaleBlog.UnitTests
{
    [TestClass]
    public class PostControllerTest
    {
        [TestMethod]
        public void Can_Paginate()
        {
            // Arrange
            Mock<IPostsRepository> mock = new Mock<IPostsRepository>();
            mock.Setup(m => m.Posts).Returns(new Post[]{
                new Post { PostID = 1, Title = "Amazon post", Body = "A post on Amazon"},
                new Post { PostID = 3, Title = "Apple post", Body = "A post on Apple"},
                new Post { PostID = 2, Title = "Facebook post", Body = "A post on Facebook"},
                new Post { PostID = 4, Title = "Oracle post", Body = "A post on Oracle"},
                new Post { PostID = 5, Title = "IBM post", Body = "A post on IBM"}
            });
            PostController controller = new PostController(mock.Object);
            controller.PageSize = 3;

            // Act
            IEnumerable<Post> result = (IEnumerable<Post>)controller.List(2).Model;

            // Assert
            Post[] postArray = result.ToArray();
            Assert.IsTrue(postArray.Length == 2);
            Assert.AreEqual(postArray[0].Title, "Oracle post");
            Assert.AreEqual(postArray[1].Title, "IBM post");
        }
    }
}
