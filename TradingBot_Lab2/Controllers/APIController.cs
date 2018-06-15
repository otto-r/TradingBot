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

namespace Lab2_Core2Test.Controllers
{
    [Produces("application/json")]
    [Route("api/")]
    [ApiController]
    public class APIController : Controller
    {
        private readonly ISentimentProvider _sentimentProvider;


        public APIController(ISentimentProvider sentimentProvider)
        {
            _sentimentProvider = sentimentProvider;
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
            var trade = TradingBot.Trade(stock);

            var tradeOrder = trade.ToString();


            //var json = JsonConvert.SerializeObject(stock);
            return tradeOrder;
        }

        [HttpGet]
        [Route("stockData/test")]
        public async Task<IActionResult> StockDataTest()
        {
            Stock stock = new Stock()
            {
                Name = "Microsoft",
                Liquidity = 1.1,
                Price = 100,
                Price200DayAverage = 99
            };

            var TradingBot = new TradingBot(_sentimentProvider);
            var trade = TradingBot.Trade(stock);

            var tradeOrder = new
            {
                trade = trade.ToString()
            };

            // var json = JsonConvert.SerializeObject(trade.ToString());

            return Ok(tradeOrder);
        }





        //-------------------------------------------------------------------------------------
        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

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
