namespace BusinessLogicLayer.Services.Analysis
{
    public interface IAnalysisService
    {
        // Gelen metni analiz eder ve -1.0 ile 1.0 arası bir skor döner
        Task<decimal> GetSentimentScoreAsync(string text);

        // Puan ve metin skoru arasındaki tutarlılığı denetler
        bool CheckConsistency(int rating, decimal sentimentScore);
    }
}