using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Project.Core.CrossCuttingConcerns.Caching;
using Project.Core.Utilities.Interceptors;
using Project.Core.Utilities.IoC;

namespace Project.Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _cacheTime;
        private ICacheManager _cacheManager;

        public CacheAspect(int cacheTime)
        {
            _cacheTime = cacheTime;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
            //Inversion of Control --> IoC
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");

            var arguments = invocation.Arguments.ToList();

            var key = $"{methodName}({string.Join(",", arguments.Select((a => a?.ToString() ?? "<Null>")))})";
            if (_cacheManager.IsAdd(key))
            {
                invocation.ReturnValue = _cacheManager.Get<ICacheManager>(key);
                return;
            }
            invocation.Proceed();
            _cacheManager.Add(key, invocation.ReturnValue, _cacheTime);
        }
    }
}
