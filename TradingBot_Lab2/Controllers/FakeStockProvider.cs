using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab2_Core2Test.Models;
using TradingBot_Lab2.Models;

namespace Lab2_Core2Test.Controllers
{
    public class FakeStockProvider : IStockProvider
    {
        public StockOrder AutoTrade(int id)
        {
            StockOrder stockOrder = new StockOrder
            {
                Id = 1,
                Stock = new Stock { Id = 100, Liquidity = 1.1, Name = "FakeStock", Price = 10, Price200DayAverage = 1 },
                NumberOfStocks = 100
            };
            return stockOrder;
        }

        IEnumerable<Stock> IStockProvider.GetAllStocks()
        {
            throw new NotImplementedException();
        }

        Stock IStockProvider.GetStockById(int id)
        {
            return new Stock { Id = 100, Liquidity = 1.1, Name = "FakeStock", Price = 10, Price200DayAverage = 1 };
        }

        StockOrder IStockProvider.StockOrder(int id)
        {
            return new StockOrder
            {
                Id = 1,
                Stock = new Stock
                {
                    Id = 100,
                    Liquidity = 1.1,
                    Name = "FakeStock",
                    Price = 10,
                    Price200DayAverage = 1
                },
                NumberOfStocks = 1
            };
        }
    }
}



