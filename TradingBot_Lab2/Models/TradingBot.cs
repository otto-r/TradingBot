using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2_Core2Test.Models
{
    public class TradingBot
    {
        private readonly ISentimentProvider _sentimentProvider;

        public TradingBot(ISentimentProvider sentimentProvider)
        {
            _sentimentProvider = sentimentProvider ?? throw new ArgumentNullException(nameof(sentimentProvider));
        }

        public TradeDecision Trade(Stock stock)
        {
            if (double.IsNaN(stock.Liquidity) || stock.Liquidity <= 0)
            {
                return TradeDecision.error;
            }

            if (stock.Price <= 0 || stock.Price200DayAverage <= 0)
            {
                return TradeDecision.error;
            }

            if (stock.Liquidity < 1)
                return TradeDecision.noTrade;

            #region Buy
            if (_sentimentProvider.GetSentiment(stock.Name) == Sentiment.positive && stock.Price < stock.Price200DayAverage)
                return TradeDecision.strongBuy;

            if (_sentimentProvider.GetSentiment(stock.Name) == Sentiment.positive && stock.Price == stock.Price200DayAverage)
                return TradeDecision.buy;

            if (_sentimentProvider.GetSentiment(stock.Name) == Sentiment.neutral && stock.Price < stock.Price200DayAverage)
                return TradeDecision.buy;
            #endregion

            #region NoTrade
            if (_sentimentProvider.GetSentiment(stock.Name) == Sentiment.neutral && stock.Price == stock.Price200DayAverage)
                return TradeDecision.noTrade;

            if (_sentimentProvider.GetSentiment(stock.Name) == Sentiment.positive && stock.Price > stock.Price200DayAverage)
                return TradeDecision.noTrade;

            if (_sentimentProvider.GetSentiment(stock.Name) == Sentiment.negative && stock.Price < stock.Price200DayAverage)
                return TradeDecision.noTrade;
            #endregion

            #region ShortSell
            if (_sentimentProvider.GetSentiment(stock.Name) == Sentiment.negative && stock.Price > stock.Price200DayAverage)
                return TradeDecision.strongShortSell;

            if (_sentimentProvider.GetSentiment(stock.Name) == Sentiment.negative && stock.Price == stock.Price200DayAverage)
                return TradeDecision.shortSell;

            if (_sentimentProvider.GetSentiment(stock.Name) == Sentiment.neutral && stock.Price > stock.Price200DayAverage)
                return TradeDecision.shortSell;
            #endregion

            return TradeDecision.error;
        }
    }
}
