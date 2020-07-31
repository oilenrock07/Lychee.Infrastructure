using System;
using System.Collections.Generic;
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

        [Obsolete("Update tries to select and update the record. Please use Attach")]
        void Update(T entity);

        void Attach(T entity);

        void Delete(T entity);

        /// <summary>
        /// Explicitly save the changes
        /// </summary>
        void SaveChanges();

        ICollection<T2> ExecuteSqlQuery<T2>(string sql, params object[] args) where T2 : class;
    }
}
