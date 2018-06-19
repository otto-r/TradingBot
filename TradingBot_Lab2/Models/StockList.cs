using Lab2_Core2Test.Models;
using System.Collections.Generic;

namespace TradingBot_Lab2.Controllers
{
    public class StockList
    {
        public static List<Stock> GetStockList()
        {
            List<Stock> stockList = new List<Stock>
            {
                new Stock{Id = 1, Liquidity = 1.5, Name= "Microsoft", Price = 100, Price200DayAverage = 87},
                new Stock{Id = 2, Liquidity = 1.7, Name= "Apple", Price = 100, Price200DayAverage = 115},
                new Stock{Id = 3, Liquidity = 0.7, Name= "Tiny Tech", Price = 1.22, Price200DayAverage = 2},
                new Stock{Id = 4, Liquidity = 1.1, Name= "Cisco", Price = 75, Price200DayAverage = 75},
                new Stock{Id = 5, Liquidity = 1.3, Name= "Netflix", Price = 130, Price200DayAverage = 125}
            };
            return stockList;
        }
    }
}
