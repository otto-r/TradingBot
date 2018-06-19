using System;
using Xunit;
using Lab2_Core2Test.Models;
using Moq;


namespace Lab2Test
{
    public class StockTradingScenarioTests
    {
        
        [Fact]
        public void Trade_LowLiquidity_Returns_NoTrade()
        {
            Mock<ISentimentProvider> mockSentimentProvider = new Mock<ISentimentProvider>();

            var tradingBot = new TradingBot(mockSentimentProvider.Object);

            var Stock = new Stock
            {
                Liquidity = 0.6,
                Name = "Alphabet",
                Price = 100,
                Price200DayAverage = 67
            };
            var decision = tradingBot.TradeEvaluation(Stock);

            Assert.Equal(TradeDecision.noTrade, decision);
        }

        [Fact]
        public void Trade_LowPrice_PositiveSentiment_Returns_StrongBuy()
        {
            Mock<ISentimentProvider> mockSentimentProvider = new Mock<ISentimentProvider>();

            mockSentimentProvider.Setup(x => x.GetSentiment(It.Is<string>(s => s == "Apple"))).Returns(Sentiment.positive);

            var tradingBot = new TradingBot(mockSentimentProvider.Object);

            var Stock = new Stock
            {
                Name = "Apple",
                Liquidity = 1.1,
                Price = 9,
                Price200DayAverage = 10
            };
            var decision = tradingBot.TradeEvaluation(Stock);

            Assert.Equal(TradeDecision.strongBuy, decision);
        }

        [Fact]
        public void Trade_LowPrice_NeutralSentiment_Returns_Buy()
        {
            Mock<ISentimentProvider> mockSentimentProvider = new Mock<ISentimentProvider>();

            mockSentimentProvider.Setup(x => x.GetSentiment(It.Is<string>(s => s == "Apple"))).Returns(Sentiment.neutral);

            var tradingBot = new TradingBot(mockSentimentProvider.Object);

            var Stock = new Stock
            {
                Name = "Apple",
                Liquidity = 1.1,
                Price = 9,
                Price200DayAverage = 10
            };
            var decision = tradingBot.TradeEvaluation(Stock);

            Assert.Equal(TradeDecision.buy, decision);
        }

        [Fact]
        public void Trade_LowPrice_NegativeSentiment_Returns_NoTrade()
        {
            Mock<ISentimentProvider> mockSentimentProvider = new Mock<ISentimentProvider>();

            mockSentimentProvider.Setup(x => x.GetSentiment(It.Is<string>(s => s == "Apple"))).Returns(Sentiment.negative);

            var tradingBot = new TradingBot(mockSentimentProvider.Object);

            var Stock = new Stock
            {
                Name = "Apple",
                Liquidity = 1.1,
                Price = 9,
                Price200DayAverage = 10
            };
            var decision = tradingBot.TradeEvaluation(Stock);

            Assert.Equal(TradeDecision.noTrade, decision);
        }

        [Fact]
        public void Trade_HighPrice_NegativeSentiment_Returns_StrongShortSell()
        {
            Mock<ISentimentProvider> mockSentimentProvider = new Mock<ISentimentProvider>();

            mockSentimentProvider.Setup(x => x.GetSentiment(It.Is<string>(s => s == "Apple"))).Returns(Sentiment.negative);

            var tradingBot = new TradingBot(mockSentimentProvider.Object);

            var Stock = new Stock
            {
                Name = "Apple",
                Liquidity = 1.1,
                Price = 11,
                Price200DayAverage = 10
            };
            var decision = tradingBot.TradeEvaluation(Stock);

            Assert.Equal(TradeDecision.strongShortSell, decision);
        }

        [Fact]
        public void Trade_HighPrice_NeutralSentiment_Returns_ShortSell()
        {
            Mock<ISentimentProvider> mockSentimentProvider = new Mock<ISentimentProvider>();

            mockSentimentProvider.Setup(x => x.GetSentiment(It.Is<string>(s => s == "Apple"))).Returns(Sentiment.neutral);

            var tradingBot = new TradingBot(mockSentimentProvider.Object);

            var Stock = new Stock
            {
                Name = "Apple",
                Liquidity = 1.1,
                Price = 11,
                Price200DayAverage = 10
            };
            var decision = tradingBot.TradeEvaluation(Stock);

            Assert.Equal(TradeDecision.shortSell, decision);
        }

        [Fact]
        public void Trade_EqualPrice_NegativeSentiment_Returns_ShortSell()
        {
            Mock<ISentimentProvider> mockSentimentProvider = new Mock<ISentimentProvider>();

            mockSentimentProvider.Setup(x => x.GetSentiment(It.Is<string>(s => s == "Apple"))).Returns(Sentiment.negative);

            var tradingBot = new TradingBot(mockSentimentProvider.Object);

            var Stock = new Stock
            {
                Name = "Apple",
                Liquidity = 1.1,
                Price = 10,
                Price200DayAverage = 10
            };
            var decision = tradingBot.TradeEvaluation(Stock);

            Assert.Equal(TradeDecision.shortSell, decision);
        }

        [Fact]
        public void Trade_HighPrice_PositiveSentiment_Returns_NoTrade()
        {
            Mock<ISentimentProvider> mockSentimentProvider = new Mock<ISentimentProvider>();

            mockSentimentProvider.Setup(x => x.GetSentiment(It.Is<string>(s => s == "Apple"))).Returns(Sentiment.positive);

            var tradingBot = new TradingBot(mockSentimentProvider.Object);

            var Stock = new Stock
            {
                Name = "Apple",
                Liquidity = 1.1,
                Price = 11,
                Price200DayAverage = 10
            };
            var decision = tradingBot.TradeEvaluation(Stock);

            Assert.Equal(TradeDecision.noTrade, decision);
        }

        [Fact]
        public void Trade_EqualPrice_PositiveSentiment_Returns_Buy()
        {
            Mock<ISentimentProvider> mockSentimentProvider = new Mock<ISentimentProvider>();

            mockSentimentProvider.Setup(x => x.GetSentiment(It.Is<string>(s => s == "Apple"))).Returns(Sentiment.positive);

            var tradingBot = new TradingBot(mockSentimentProvider.Object);

            var Stock = new Stock
            {
                Name = "Apple",
                Liquidity = 1.1,
                Price = 10,
                Price200DayAverage = 10
            };
            var decision = tradingBot.TradeEvaluation(Stock);

            Assert.Equal(TradeDecision.buy, decision);
        }

        [Fact]
        public void Trade_EqualPrice_NeutralSentiment_Returns_NoTrade()
        {
            Mock<ISentimentProvider> mockSentimentProvider = new Mock<ISentimentProvider>();

            mockSentimentProvider.Setup(x => x.GetSentiment(It.Is<string>(s => s == "Apple"))).Returns(Sentiment.neutral);

            var tradingBot = new TradingBot(mockSentimentProvider.Object);

            var Stock = new Stock
            {
                Name = "Apple",
                Liquidity = 1.1,
                Price = 10,
                Price200DayAverage = 10
            };
            var decision = tradingBot.TradeEvaluation(Stock);

            Assert.Equal(TradeDecision.noTrade, decision);
        }

        [Fact]
        public void Trade_InvalidParameters_Returns_()
        {
            Mock<ISentimentProvider> mockSentimentProvider = new Mock<ISentimentProvider>();

            mockSentimentProvider.Setup(x => x.GetSentiment(It.Is<string>(s => s == "Apple"))).Returns(Sentiment.neutral);

            var tradingBot = new TradingBot(mockSentimentProvider.Object);

            var Stock = new Stock { };
            var decision = tradingBot.TradeEvaluation(Stock);

            Assert.Equal(TradeDecision.error, decision);
        }
    }
}
