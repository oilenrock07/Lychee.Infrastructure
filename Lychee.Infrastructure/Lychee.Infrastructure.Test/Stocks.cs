using System.ComponentModel.DataAnnotations;

namespace Lychee.Infrastructure.Test
{
    public class Stocks
    {
        [Key]
        public string StockCode { get; set; }
        public string Name { get; set; }
        public string StockType { get; set; }
    }
}
