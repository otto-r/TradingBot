namespace Lab2_Core2Test.Models
{
    public interface ISentimentProvider
    {
        Sentiment GetSentiment(string stockName);
    }
}