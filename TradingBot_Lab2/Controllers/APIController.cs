using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Lab2_Core2Test.Models;
using System.Net;
using System.Net.Http;
using System.Text;
using TradingBot_Lab2.Models;
using TradingBot_Lab2.Controllers;

namespace Lab2_Core2Test.Controllers
{
    [Produces("application/json")]
    [Route("api/")]
    [ApiController]
    public class APIController : Controller
    {
        private readonly ISentimentProvider _sentimentProvider;
        private readonly IStockProvider _stockProvider;

        public APIController(ISentimentProvider sentimentProvider, IStockProvider stockProvider)
        {
            _sentimentProvider = sentimentProvider;
            _stockProvider = stockProvider;
        }

        [HttpGet]
        [Route("autoTrade")]
        public async Task<IActionResult> AutoTrade(int id)
        {
            Stock stockFromDb = _stockProvider.GetStockById(id);

            var TradingBot = new TradingBot(_sentimentProvider);
            var trade = TradingBot.TradeEvaluation(stockFromDb);

            StockOrder stockOrder = new StockOrder();

            if (trade == TradeDecision.buy || trade == TradeDecision.strongBuy)
            {
                stockOrder.Id = 1;
                stockOrder.Stock = stockFromDb;
                stockOrder.NumberOfStocks = 10;
                var tradeOrder = new
                {
                    test = stockOrder.Id
                };
                    //stockOrder = stockOrder.ToString()
                return Ok(tradeOrder);
            }

            return Ok(new { error = "error" });
        }

        [HttpGet]
        [Route("getSentiment")]
        public async Task<IActionResult> StockDataTest(Stock stock)
        {
            List<Stock> stockList = StockList.GetStockList();

            var TradingBot = new TradingBot(_sentimentProvider);
            var trade = TradingBot.TradeEvaluation(stock);

            var tradeOrder = new
            {
                trade = trade.ToString()
            };

            return Ok(tradeOrder);
        }

        //List<Stock> stockList = StockList.GetStockList();
        [HttpGet]
        [Route("stockInfo/{id}")]
        public async Task<IActionResult> StockInfo(int id)
        {
            Stock stockFromDb = _stockProvider.GetStockById(id);

            var Stock = new
            {
                stockFromDb.Name,
                stockFromDb.Liquidity,
                stockFromDb.Price,
                stockFromDb.Price200DayAverage

            };

            return Ok(Stock);
        }

        [HttpGet]
        [Route("orderStock/{id}")]
        public async Task<IActionResult> StockOrder(int id)
        {
            Stock stockFromDb = _stockProvider.GetStockById(id);

            var stockOrderFromProvider = _stockProvider.StockOrder(id);

            var stockOrder = new
            {
                stockOrderFromProvider.Id,
                stockOrderFromProvider.NumberOfStocks,
                stockOrderFromProvider.Stock
            };

            return Ok(stockOrder);
        }

    }
}
