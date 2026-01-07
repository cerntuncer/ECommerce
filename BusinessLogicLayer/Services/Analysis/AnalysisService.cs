namespace BusinessLogicLayer.Services.Analysis
{
    public class AnalysisService : IAnalysisService
    {
        public async Task<decimal> GetSentimentScoreAsync(string text)
        {
            // Gerçek projede burası OpenAI veya Azure'a istek atar.
            // Örnek: Kötü kelimeler geçiyorsa negatif puan verelim.
            string lowText = text.ToLower();
            if (lowText.Contains("kötü") || lowText.Contains("berbat") || lowText.Contains("hiç beğenmedim"))
                return -0.8m;

            return 0.8m; // Varsayılan pozitif
        }

        public bool CheckConsistency(int rating, decimal sentimentScore)
        {
            // Eğer rating yüksek (4-5) ve duygu negatifse (-0.5 altı) -> TUTARSIZ
            if (rating >= 4 && sentimentScore < 0) return false;

            // Eğer rating düşük (1-2) ve duygu pozitifse (+0.5 üstü) -> TUTARSIZ
            if (rating <= 2 && sentimentScore > 0) return false;

            return true; // Diğer durumlar tutarlı
        }
    }
}