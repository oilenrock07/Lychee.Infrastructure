using System;
using System.Linq;
using System.Linq.Expressions;

namespace Lychee.Infrastructure.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);

        IQueryable<T> GetAll();

        IQueryable<T> Find(Expression<Func<T, bool>> expression);

        T FirstOrDefault(System.Linq.Expressions.Expression<Func<T, bool>> expression);
        T Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        /// <summary>
        /// Explicitly save the changes
        /// </summary>
        void SaveChanges();
    }
}
