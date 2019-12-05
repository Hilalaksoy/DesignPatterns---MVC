using Blog.Core.Entities.Access;
using Blog.Core.Entities.Common;
using Blog.Core.Entities.Docs;
using Blog.Data.GenericRepository;
using Blog.Data.UnitofWork;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.IoC.Ninject
{
    public static class NinjectConfig
    {
        /*Core ve data katmanındaki UnitofWork bağımlılık yönetimi burada yapılmalıdır. Diğer katmandaki projelere implement etmemizi sağlayacaktır. Örnek olarak UnitofWork ü Web katmanında kullanmak istenildiğinde implement edilmesi için kullanılacaktır. Ninject bağımlılıkları enjekte etmekte kullanılan Open Source ir kütüphanedir.Ninject den yararlanmak için bulunduğu projenin içerisine referanslara Ninject package eklenmelidir.*/
        public static IKernel CreateKernal()
        {
            //Ninject çekirdeği, kendisine verilen arayüz ve sınıf arasında bir bağlantı kurmakta ve aynı çekirdekten talep edilen nesne üzerinde bu yapılar mevcutsa otomatik bu bağlantıyı sağlamaktadır.
            IKernel kernel = new StandardKernel();

            kernel.Bind<IUnitofWork>().To<UnitofWork>().InSingletonScope();

            //InSingletonScope() = Ninject üzerinden  nesnenin dispose edilebilmesini sağlar.

            /*Core katmanındaki entitylerimizin bağımlılıkları */
            
            //Access schema
            kernel.Bind<IGenericRepository<User>>().To<GenericRepository<User>>();
            kernel.Bind<IGenericRepository<Role>>().To<GenericRepository<Role>>();
            kernel.Bind<IGenericRepository<UserRole>>().To<GenericRepository<UserRole>>();

            //Common schema
            kernel.Bind<IGenericRepository<Place>>().To<GenericRepository<Place>>();
            kernel.Bind<IGenericRepository<Comment>>().To<GenericRepository<Comment>>();
            kernel.Bind<IGenericRepository<Address>>().To<GenericRepository<Address>>();
            kernel.Bind<IGenericRepository<District>>().To<GenericRepository<District>>();
            kernel.Bind<IGenericRepository<City>>().To<GenericRepository<City>>();
            kernel.Bind<IGenericRepository<Country>>().To<GenericRepository<Country>>();

            //Docs schema
            kernel.Bind<IGenericRepository<Media>>().To<GenericRepository<Media>>();


            //TODO: Servis katmanları bağımlılık yönetimi yapılacaktır.

            return kernel;           
        }
    }
}
