using Lab2_Core2Test.Models;

namespace TradingBot_Lab2.Models
{
    public class StockOrder
    {
        public int Id { get; set; }
        public Stock Stock { get; set; }
        public int NumberOfStocks { get; set; }
    }
}
