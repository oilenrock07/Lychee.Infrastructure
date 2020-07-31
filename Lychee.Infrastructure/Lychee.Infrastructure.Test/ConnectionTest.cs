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
    public class ConnectionTest
    {

        [Test]
        public void TestSqlServer()
        {
            var databaseFactory = new DatabaseFactory(new StockContext());
            var repository = new Repository<Stocks>(databaseFactory.GetContext());
            var stocks = repository.GetAll().ToList();
        }

        [Test]
        public void CanCreateRecordWithoutPopulatingTheRelatedData()
        {
            var databaseFactory = new DatabaseFactory(new StockContext());
            var repository = new Repository<WatchListGroup>(databaseFactory.GetContext());

            var watchListGroup = new WatchListGroup
            {
                GroupName = "Owned Stocks"
            };

            repository.Add(watchListGroup);
            repository.SaveChanges();
        }

        [Test]
        public void CanAddRecordToRelatedData()
        {
            var databaseFactory = new DatabaseFactory(new StockContext());
            var repository = new Repository<WatchListGroup>(databaseFactory.GetContext());

            var group = repository.GetById(1);
            group.WatchLists.Add(new Watchlist { StockCode = "Test2", DateCreated =  DateTime.Now});

            repository.SaveChanges();
        }

        [Test]
        public void CanUpdateRecord()
        {
            var databaseFactory = new DatabaseFactory(new StockContext());
            var repository = new Repository<Stocks>(databaseFactory.GetContext());

            var stock = repository.FirstOrDefault(x => x.StockCode == "2GO");
            repository.Attach(stock);
            stock.StockType = "Basura";
            repository.SaveChanges();
        }

        [Test]
        public void CanUpdateRelatedcord()
        {
            var databaseFactory = new DatabaseFactory(new StockContext());
            var repository = new Repository<WatchListGroup>(databaseFactory.GetContext());

            var group = repository.GetById(1);
            var item2 = group.WatchLists.FirstOrDefault(x => x.WatchListId == 2);
            item2.Cutloss = 5m;

            repository.SaveChanges();
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
