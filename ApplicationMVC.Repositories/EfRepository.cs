using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace ApplicationMVC.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        private DbSet<T> dbSet;
        private DbContext dbContext;

        public EfRepository(DbContext context)
        {
            this.DbContext = context;
            this.DbSet = this.DbContext.Set<T>();
        }

        protected DbSet<T> DbSet
        {
            get
            {
                return this.dbSet;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The dbSet cannot be null.");
                }

                this.dbSet = value;
            }
        }

        protected DbContext DbContext
        {
            get
            {
                return this.dbContext;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
                }

                this.dbContext = value;
            }
        }

        public virtual IQueryable<T> GetAll()
        {
            return this.DbSet;
        }

        public virtual T GetById(int id)
        {
            return this.DbSet.Find(id);
        }

        public virtual T Add(T entityObject)
        {
            DbEntityEntry entry = this.DbContext.Entry(entityObject);

            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.DbSet.Add(entityObject);
            }

            this.DbContext.SaveChanges();

            return entityObject;
        }

        public virtual void Delete(T entity)
        {
            DbEntityEntry entry = this.DbContext.Entry(entity);

            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.DbSet.Attach(entity);
                this.DbSet.Remove(entity);
            }

            this.DbContext.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            var entity = this.GetById(id);

            if (entity != null)
            {
                this.Delete(entity);
            }
        }

        public virtual T Update(int id, T item)
        {
            DbEntityEntry entry = this.DbContext.Entry(item);

            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(item);
            }

            entry.State = EntityState.Modified;
            this.DbContext.SaveChanges();

            return item;
        }
    }
}
