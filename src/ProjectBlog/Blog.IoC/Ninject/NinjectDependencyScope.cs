using Ninject;
using Ninject.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;

namespace Blog.IoC.Ninject
{
    /*Ninject bağımlılık kapsayıcı classı NinjectDependencyResolver sınıfını türetmemiz için kullanılan base classdır. Bunun sebebi ise IDependencyResolver interface tipinin barındırdığı BeginScope() metodudur. */
    public class NinjectDependencyScope : IDependencyScope
    {
        IResolutionRoot resolver;

        public NinjectDependencyScope(IResolutionRoot resolver)
        {
            this.resolver = resolver;
        }

        public void Dispose()
        {
            IDisposable disposable = resolver as IDisposable;
            if(disposable != null)
            {
                disposable.Dispose();
            }
        }

        public object GetService(Type serviceType)
        {
            if(resolver == null)
            {
                throw new ObjectDisposedException("this", "This scope has been disposed");
            }
            return resolver.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (resolver == null)
            {
                throw new ObjectDisposedException("this", "This scope has been disposed");
            }
            return resolver.GetAll(serviceType);
        }
    }
}
