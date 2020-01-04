using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lychee.Infrastructure.Test
{
    public class StockContext : DbContext
    {
        public StockContext() : base("ConnectionString.MsSql")
        {
            
        }

        public virtual IDbSet<Stocks> Stocks { get; set; }
    }
}
