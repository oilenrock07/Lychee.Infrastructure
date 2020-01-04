using System.Data.Entity;

namespace Lychee.Infrastructure.Interfaces
{
    public interface IDatabaseFactory
    {
        DbContext GetContext();
        void SaveChanges();
    }
}
