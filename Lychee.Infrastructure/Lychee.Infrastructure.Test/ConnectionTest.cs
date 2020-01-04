using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Lychee.Infrastructure.Test
{
    [TestFixture]
    public class ConnectionTest
    {
        [Test]
        public void TestSqlServer()
        {
            var databaseFactory = new DatabaseFactory(new StockContext());
            var repository = new Repository<Stocks>(databaseFactory.GetContext());

            var stocks = repository.GetAll().ToList();
        }
    }
}
