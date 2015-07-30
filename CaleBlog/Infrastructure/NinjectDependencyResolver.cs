using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using CaleBlog.Domain.Abstract;
using CaleBlog.Domain.Concrete;
using CaleBlog.Domain.Entities;
using CaleBlog.WebUI.Infrastructure.Abstract;
using CaleBlog.WebUI.Infrastructure.Concrete;

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
            kernel.Bind<IPostsRepository>().To<EFPostRepository>();
            kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }
    }
}