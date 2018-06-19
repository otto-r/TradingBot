using Xunit;
using Moq;
using Lab2_Core2Test.Controllers;
using Lab2_Core2Test.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using TradingBot_Lab2.Models;

namespace Lab2Test
{
    public class APIControllerTests
    {

        [Fact]
        public void InvalidParameter_Returns_Error()
        {
            Mock<ISentimentProvider> mockSentimentProvider = new Mock<ISentimentProvider>();
            Mock<IStockProvider> mockStockProvider = new Mock<IStockProvider>();
            APIController apiCtrlr = new APIController(mockSentimentProvider.Object, mockStockProvider.Object);

            Stock stock = new Stock();
            Assert.Equal("error", apiCtrlr.StockData(2));
        }

        [Fact]
        public void APIController_GetStockInfo_Successful()
        {
            Mock<ISentimentProvider> mockSentimentProvider = new Mock<ISentimentProvider>();
            Mock<IStockProvider> mockStockProvider = new Mock<IStockProvider>();
            APIController APIController = new APIController(mockSentimentProvider.Object, mockStockProvider.Object);

            APIController.StockInfo(1);

            mockStockProvider.Verify(m => m.GetStockById(1), Times.Once());
        }



        [Fact]
        public void LowLiquidity_Returns_NoTrade()
        {
            Mock<ISentimentProvider> mockSentimentProvider = new Mock<ISentimentProvider>();
            Mock<IStockProvider> mockStockProvider = new Mock<IStockProvider>();
            APIController APIController = new APIController(mockSentimentProvider.Object, mockStockProvider.Object);
            mockSentimentProvider.Setup(x => x.GetSentiment(It.Is<string>(s => s == "Microsoft"))).Returns(Sentiment.positive);

            Stock stock = new Stock
            {
                Id = 1,
                Name = "Microsoft",
                Liquidity = 0.8,
                Price = 100,
                Price200DayAverage = 87
            };

            var tradingBot = new TradingBot(mockSentimentProvider.Object);
            var decision = tradingBot.TradeEvaluation(stock);

           

           
        }
    }
}