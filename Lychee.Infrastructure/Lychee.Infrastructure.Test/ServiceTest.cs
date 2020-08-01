using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lychee.Stocks.Entities;
using NUnit.Framework;

namespace Lychee.Infrastructure.Test
{
    [TestFixture]
    public class ServiceTest
    {

        [Test]
        public void TestSqlServer()
        {
            var databaseFactory = new DatabaseFactory(new StockContext());
            var repository = new Repository<Stocks>(databaseFactory.GetContext());
            var service = new Service<Stocks>(repository);

            var all = service.GetAll();
        }
    }
}
