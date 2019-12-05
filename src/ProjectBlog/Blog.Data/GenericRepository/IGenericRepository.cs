using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.GenericRepository
{
    public interface IGenericRepository<T>  where T : class
    {
        /// <summary>
        /// Entity'e göre tümm listeyi getirir.
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Where clause'a göre tüm listeyi getirir.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Id'ye göre entity getirir.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(object id);

        /// <summary>
        /// Where clause'a göre entity getirir.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        T Get(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Db'ye bir adet entity eklemeyi sağlar. (Sql - Insert)
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);

        /// <summary>
        /// Db'ye liste halinde entityleri eklemeyi sağlar.
        /// </summary>
        /// <param name="entityList"></param>
        void AddRange(List<T> entityList);

        /// <summary>
        /// Db'de entity üzerinde değişiklik yapmayı sağlar.
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// Entity silmemizi sağlar.
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);
    }
}
