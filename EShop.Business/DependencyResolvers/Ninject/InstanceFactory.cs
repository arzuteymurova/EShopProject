using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.Business.DependencyResolvers.Autofac;
using Ninject;

namespace EShop.Business.DependencyResolvers.Ninject
{
    public static class InstanceFactory
    {
        public static T GetInstance<T>()
        {
            var kernel = new StandardKernel(new BusinessModule());
            
            return kernel.Get<T>();
        }
    }
}
