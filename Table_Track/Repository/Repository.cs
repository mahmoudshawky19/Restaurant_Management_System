using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Table_Track.Data;
using Table_Track.Repository.IRepository;

namespace Table_Track
{
    public class Repository <T>: IRepository <T> where T : class
    {
        ApplicationDbContext dbContext;// = new ApplicationDbContext();
        DbSet<T> dbSet;
        public Repository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<T>();
        }

        // CRUD
        public IQueryable<T> GetAll(Expression<Func<T, object>>[]? includeProp = null, Expression<Func<T, bool>>? expression = null, bool tracked = true )
        {
            IQueryable<T> query = dbSet;
            if (includeProp != null)
            {
                foreach (var item in includeProp)
                {
                    query = query.Include(item);

                }
            }
            if (expression != null)
            {
                query = query.Where(expression);
            }
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
         
            return query ;
        }

        public IQueryable<T> GetOne(Expression<Func<T, object>>[]? includeProp = null, Expression<Func<T, bool>>? expression = null, bool tracked = true)
        {
            return GetAll(includeProp, expression, tracked);
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Edit(T entity)
        {
            dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public void Commit()
        {
            dbContext.SaveChanges();
        }
  

    }
}
