using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lychee.Stocks.Entities;

namespace Lychee.Infrastructure.Test
{
    public class StockContext : DbContext
    {
        public StockContext() : base("ConnectionString.MsSql")
        {
            
        }

        public virtual IDbSet<Stocks> Stocks { get; set; }
        public virtual IDbSet<Watchlist> WatchLists { get; set; }
        public virtual IDbSet<WatchListGroup> WatchListGroups { get; set; }

    }
}
