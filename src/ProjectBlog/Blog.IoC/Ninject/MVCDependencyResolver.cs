using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Blog.IoC.Ninject
{
    /// <summary>
    /// MVC için gerekli bağımlılık kapsayıcısıdır. Bu bağımlılık sayesinde servisteki metotlara erişebilmesi sağlanır.
    /// </summary>
    public class MVCDependencyResolver : NinjectDependencyScope ,System.Web.Mvc.IDependencyResolver
    {
        private readonly IKernel kernel;

        public MVCDependencyResolver(IKernel kernel) : base(kernel)
        {
            //NinjectConfig de oluşturulan kernel burada kullanılmak için constructur sayesinde alındı.
            this.kernel = kernel;
        }

        /// <summary>
        /// Bağımlılık kapsayıcı başlatma.
        /// </summary>
        /// <returns></returns>
        public System.Web.Http.Dependencies.IDependencyScope BeginScope()
        {
            return new NinjectDependencyScope(kernel.BeginBlock());
        }
    }
}
