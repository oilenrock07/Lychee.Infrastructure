using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

            var stock = repository.FirstOrDefault(x => x.StockCode == "2GO");
            repository.Attach(stock);
            stock.StockType = "Basura";
            repository.SaveChanges();
            //var stocks = repository.GetAll().ToList();
        }

        [Test]
        public void AddOrUpdateTest()
        {

        }

        [Test]
        public void TestExecutingStoredProcedure()
        {
            var databaseFactory = new DatabaseFactory(new StockContext());
            var repository = new Repository<Stocks>(databaseFactory.GetContext());

            var days = new SqlParameter {ParameterName = "Days", Value = 10};
            var losingStreak = new SqlParameter { ParameterName = "LosingWinningStreak", Value = 8 };

            var stocks =
                repository.ExecuteSqlQuery<StockTrendReportModel>("exec RetrieveStockTrendReport @Days, @LosingWinningStreak", days, losingStreak);
        }
    }
}
