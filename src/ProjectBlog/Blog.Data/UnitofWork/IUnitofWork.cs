using Blog.Data.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.UnitofWork
{
    public interface IUnitofWork : IDisposable
    {
        IGenericRepository<T> GetRepository<T>() where T : class;

        /// <summary>
        /// Değişiklikleri kaydet.
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        /// <summary>
        /// Transaction başlat
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// Kayıt esnasında sorun olmazsa transaction bitir.
        /// </summary>
        void Commit();

        /// <summary>
        /// Kayıt esnasında sorun olursa değişiklikleri geri al.
        /// </summary>
        void Rollback();

        
    }
}
