using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.GenericRepository
{
    //Veritabanı işlemlerinde(CRUD), kod tekrarından kaçınmak için kullanılan Design Pattern'dır.
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        
        private readonly Context.Context _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(Context.Context context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public IQueryable<T> GetAll(Expression<Func<T,bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public T Get(Expression<Func<T,bool>> predicate)
        {
            return _dbSet.Where(predicate).SingleOrDefault();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void AddRange(List<T> entityList)
        {
            _dbSet.AddRange(entityList);
        }

        /*Entry(object) , db nin izleme bilgilerini ve işlemlerini değiştirmeye erişim sağlar.
          Belirtilen durumda (Modified) entityi izleme.
          Attach() db de varlığı zaten bilinen entity tekrardan doldurmak için kullanılan metot. 
        */
        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
        //EntityState.Detached -> nesne var ancak izlenmiyor anlamına gelir.
        public void Delete(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
                _dbSet.Attach(entity);
            _dbSet.Remove(entity);
        }

    }
}
