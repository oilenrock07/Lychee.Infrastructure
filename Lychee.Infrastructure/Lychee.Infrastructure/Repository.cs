using System;
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

        public virtual T FirstOrDefault(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return DbSet.FirstOrDefault(expression);
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
    }
}
