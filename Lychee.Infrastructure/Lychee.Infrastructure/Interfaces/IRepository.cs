﻿using System;
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

        T FirstOrDefault();
        T FirstOrDefault(Expression<Func<T, bool>> expression);

        T LastOrDefault();
        T LastOrDefault(Expression<Func<T, bool>> expression);
        T Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        /// <summary>
        /// Explicitly save the changes
        /// </summary>
        void SaveChanges();

        ICollection<T2> ExecuteSqlQuery<T2>(string sql, params object[] args) where T2 : class;
    }
}
