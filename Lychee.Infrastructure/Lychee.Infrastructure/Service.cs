using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Lychee.Infrastructure.Interfaces;

namespace Lychee.Infrastructure
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public virtual List<T> GetAll()
        {
            return _repository.GetAll().ToList();
        }


        public virtual void AddAndSave(List<T> list)
        {
            foreach (var item in list)
            {
                _repository.Add(item);
            }

            _repository.SaveChanges();
        }

        public virtual void AddAndSave(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            _repository.Add(entity);
            _repository.SaveChanges();
        }

        public virtual void DeleteAndSave(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                _repository.Delete(entity);
                _repository.SaveChanges();
            }
        }
    }
}
