using System.Collections.Generic;

namespace Lychee.Infrastructure.Interfaces
{
    public interface IService<T>
    {
        T GetById(int id);

        List<T> GetAll();
        void AddAndSave(List<T> list);

        void AddAndSave(T entity);

        void DeleteAndSave(int id);
    }
}
