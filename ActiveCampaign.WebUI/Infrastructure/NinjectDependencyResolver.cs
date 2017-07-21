using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ActiveCampaign.Domain.Abstract;
using ActiveCampaign.Domain.Concrete;
using Ninject;

namespace ActiveCampaign.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
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
            kernel.Bind<IListRepository>().To<EFListRepository>();
            kernel.Bind<IContactRepository>().To<EFContactRepository>();
            kernel.Bind<ICampaignRepository>().To<EFCampaignRepository>();
            kernel.Bind<IMessageRepository>().To<EFMessageRepository>();
        }
    }
}