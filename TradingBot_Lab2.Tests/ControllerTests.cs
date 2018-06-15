using Xunit;
using Moq;
using Lab2_Core2Test.Controllers;
using Lab2_Core2Test.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;

namespace Lab2Test
{
    public class APIControllerTests
    {

        //private readonly ISentimentProvider _sentimentProvider;

        //public APIControllerTests(ISentimentProvider sentimentProvider)
        //{
        //    _sentimentProvider = sentimentProvider ?? throw new ArgumentNullException(nameof(sentimentProvider));
        //}

        [Fact]
        public void TestName()
        {
            Mock<ISentimentProvider> mockSentimentProvider = new Mock<ISentimentProvider>();
            APIController apiCtrlr = new APIController(mockSentimentProvider.Object);


            Stock stock = new Stock();
            Assert.Equal("error",apiCtrlr.StockData(2));
            
        }

    }
}