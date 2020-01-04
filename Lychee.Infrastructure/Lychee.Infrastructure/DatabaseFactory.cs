using System.Data.Entity;
using Lychee.Infrastructure.Interfaces;

namespace Lychee.Infrastructure
{
    public class DatabaseFactory : IDatabaseFactory
    {
        private readonly DbContext _context;

        public DatabaseFactory(DbContext context)
        {
            _context = context;
        }

        public virtual DbContext GetContext()
        {
            return _context;
        }

        public virtual void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
