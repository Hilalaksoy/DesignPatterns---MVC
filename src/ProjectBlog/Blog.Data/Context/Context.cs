using Blog.Core.Entities.Access;
using Blog.Core.Entities.Common;
using Blog.Core.Entities.Docs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Context
{
    public class Context:DbContext
    {
        /*Birbiri ile ilişkili olan tabloların kayıtları gerçekleştirilirken Eğer bir hata alınıyorsa, yapılan değişikliklerin geriye alınması için DbContextTransaction nesnesi kullanılır. */
        private readonly Context _context;
        DbContextTransaction _transaction;
   
        public Context() : base("server=.;database= TravelDb; uid=sa; pwd=123;")
        {
        }

        /// <summary>
        /// Schema: Access - Yetki ve Roller
        /// </summary>
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        /// <summary>
        /// Schema: Common - Ortak tablolar
        /// </summary>
        public DbSet<Place> Places { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }

        /// <summary>
        /// Schema: Docs - Db de saklanan resim,dosya vb. verileri barındıran tablolar
        /// </summary>
        public DbSet<Media> Medias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Model oluşturulurken tabloların adı ve şema isimleri verilerek model oluşturulur.
            modelBuilder.Entity<Role>().ToTable("Roles", "access");
            modelBuilder.Entity<User>().ToTable("Users", "access");
            modelBuilder.Entity<UserRole>().ToTable("UserRoles", "access");

            modelBuilder.Entity<Place>().ToTable("Places", "common");
            modelBuilder.Entity<Comment>().ToTable("Comments", "common");
            modelBuilder.Entity<Address>().ToTable("Addresses", "common");
            modelBuilder.Entity<District>().ToTable("Districts", "common");
            modelBuilder.Entity<City>().ToTable("Cities", "common");
            modelBuilder.Entity<Country>().ToTable("Countries", "common");

            modelBuilder.Entity<Media>().ToTable("Medias", "docs");
            base.OnModelCreating(modelBuilder);
        }

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }
        public void Commit()
        {
            _transaction.Commit();
        }
        public void Rollback()
        {
            _transaction.Rollback();
        }
    }
}
