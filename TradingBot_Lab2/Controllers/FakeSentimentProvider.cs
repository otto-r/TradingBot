using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab2_Core2Test.Models;

namespace Lab2_Core2Test.Controllers
{
    public class FakeSentimentProvider : ISentimentProvider
    {
        public Sentiment GetSentiment(string stockName)
        {


            return Sentiment.positive;
        }
    }
}
