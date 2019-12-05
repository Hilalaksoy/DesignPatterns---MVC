using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Blog.IoC.Ninject
{
    /// <summary>
    /// API için gerekli bağımlılık kapsayıcısı
    /// </summary>
    public class ApiDependencyResolver : NinjectDependencyScope, System.Web.Http.Dependencies.IDependencyResolver
    {
        private readonly IKernel kernel;

        public ApiDependencyResolver(IKernel kernel) :base(kernel)
        {
            this.kernel = kernel;
        }
        /// <summary>
        /// Bağımlılık kapsayıcıyı başlatma.
        /// </summary>
        /// <returns></returns>
        public System.Web.Http.Dependencies.IDependencyScope BeginScope()
        {
            return new NinjectDependencyScope(kernel.BeginBlock());
        }
    }
}
