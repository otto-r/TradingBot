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

        // GET: api/<controller>
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get()
        {
            var json = new
            {
                test = "test"
            };

            return Ok(json);
        }

        [HttpGet]
        [Route("stockData")]
        public string StockData(int id)
        {
            var stock = new Stock
            {
                Name = "Microsoft",
                Liquidity = 1.1,
                Price = 100,
                Price200DayAverage = 99
            };

            var TradingBot = new TradingBot(_sentimentProvider);
            var trade = TradingBot.TradeEvaluation(stock);

            var tradeOrder = trade.ToString();


            //var json = JsonConvert.SerializeObject(stock);
            return tradeOrder;
        }

        [HttpGet]
        [Route("getSentiment")]
        public async Task<IActionResult> StockDataTest(Stock stock)
        {
            List<Stock> stockList = StockList.GetStockList();
            //Stock stock = new Stock()
            //{
            //    Name = "Microsoft",
            //    Liquidity = 1.1,
            //    Price = 100,
            //    Price200DayAverage = 99
            //};

            var TradingBot = new TradingBot(_sentimentProvider);
            var trade = TradingBot.TradeEvaluation(stock);

            var tradeOrder = new
            {
                trade = trade.ToString()
            };

            // var json = JsonConvert.SerializeObject(trade.ToString());

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




        //-------------------------------------------------------------------------------------
        // GET api/<controller>/5

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


    }
}
