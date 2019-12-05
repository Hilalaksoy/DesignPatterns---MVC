using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Data.GenericRepository;

namespace Blog.Data.UnitofWork
{
    public class UnitofWork : IUnitofWork
    {
        private readonly Context.Context _context;
        private DbContextTransaction trans = null;
        private bool disposed = false;

        public UnitofWork(Context.Context context)
        {
            //Codefirst ile yapılan değişiklikleri db ye otomatik olarak (migration) yapmasını engellemek için yapılabilir.
            Database.SetInitializer<Context.Context>(null);
            if (context == null)
                throw new ArgumentException("context is null!");
            _context = context;
        }

        public IGenericRepository<T> GetRepository<T>() where T : class
        {
            return new GenericRepository<T>(_context);
        }
     
        public void BeginTransaction()
        {
            trans = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            trans.Commit();
        }

        public void Rollback()
        {
            trans.Rollback();
        }
        public int SaveChanges()
        {
            int affectedRow = 0;
            try
            {
                affectedRow = _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var message = string.Empty;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        message = string.Format("Property: {0}, Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                    }
                }
                throw new Exception(message,dbEx);
            }
            return affectedRow;
        }

        /* Performans ve bellek yönetimi önemlidir.
           Heap de oluşturulan class ve nesneler değişkenlerin kullanımı bittikten sonra C# dilinde GarbageCollector ile silindiği biliniyor.
           Bu temizliğin yapılacağı zaman belirsizdir.Bu yazılım açısından performans kaybına neden olabilmektedir. Bu garbage collectorun
           yaptığı işlemi biz kendimiz yönetebiliriz. Performansı ve belleği(RAM) verimli kullanmış oluruz.*/
        public virtual void Dispose(bool disposing)
        {
           if (!this.disposed)
           {
               if (disposing)
               {
                   _context.Dispose();
               }
           }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
