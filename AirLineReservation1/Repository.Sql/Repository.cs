using AirLineReservation1.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirLineReservation1.Repository;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace AirLineReservation1.Repository.Sql
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected AirLineContext AirLineContext { get; set; }

        public Repository(AirLineContext repositoryContext)
        {
            this.AirLineContext = repositoryContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.AirLineContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.AirLineContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            this.AirLineContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.AirLineContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.AirLineContext.Set<T>().Remove(entity);
        }
        public async Task SaveAsync()
        {
            await AirLineContext.SaveChangesAsync();
        }
    }
}
