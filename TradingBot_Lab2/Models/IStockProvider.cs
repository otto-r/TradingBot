using Lab2_Core2Test.Models;
using System.Collections.Generic;

namespace TradingBot_Lab2.Models
{
    public interface IStockProvider
    {
        IEnumerable<Stock> GetAllStocks();
        Stock GetStockById(int id);
        StockOrder StockOrder();
        StockOrder AutoTrade(int id);
    }
}
