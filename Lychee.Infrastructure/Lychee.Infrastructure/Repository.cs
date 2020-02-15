using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Lychee.Infrastructure.Interfaces;

namespace Lychee.Infrastructure
{
    public class Repository<T> : IRepository<T> 
        where T: class
    {
        private readonly DbContext _context;

        private IDbSet<T> _dbset;
        public virtual IDbSet<T> DbSet
        {
            get => _dbset ?? _context.Set<T>();
            set => _dbset = value;
        }

        public Repository(DbContext context)
        {
            _context = context;
        }

        public virtual T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public virtual IQueryable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return DbSet.Where(expression);
        }

        public virtual T FirstOrDefault()
        {
            return DbSet.FirstOrDefault();
        }

        public virtual T FirstOrDefault(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return DbSet.FirstOrDefault(expression);
        }

        public virtual T LastOrDefault()
        {
            return DbSet.LastOrDefault();
        }

        public virtual T LastOrDefault(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return DbSet.LastOrDefault(expression);
        }

        public virtual T Add(T entity)
        {
            DbSet.Add(entity);

            return entity;
        }

        public virtual void Update(T entity)
        {
            DbSet.AddOrUpdate(entity);
        }

        public virtual void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public ICollection<T2> ExecuteSqlQuery<T2>(string sql, params object[] args) where T2 : class
        {
            return _context.Database.SqlQuery<T2>(sql, args).ToList();
        }
    }
}
