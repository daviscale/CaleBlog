using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using CaleBlog.Domain.Abstract;
using CaleBlog.Domain.Entities;

using Moq;

using Ninject;

namespace CaleBlog.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParm)
        {
            kernel = kernelParm;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType); 
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            Mock<IPostsRepository> mock = new Mock<IPostsRepository>();
            mock.Setup(m => m.Posts).Returns(new List<Post> { 
                new Post { Title = "Title 1", Body = "body 1" },
                new Post { Title = "title 2", Body = "body 2" },
                new Post { Title = "title 3", Body = "body 3" }
            });

            kernel.Bind<IPostsRepository>().ToConstant(mock.Object);
        }
    }
}