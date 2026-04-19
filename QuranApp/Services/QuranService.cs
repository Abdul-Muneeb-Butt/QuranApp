namespace QuranApp.Services
{
    public class QuranService
    {
        private readonly HttpClient _http;

        public QuranService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Surah>> GetSurahsAsync()
        {
            var response = await _http.GetFromJsonAsync<QuranResponse>
            ("https://api.alquran.cloud/v1/surah");

            return response?.Data ?? new List<Surah>();
        }

        public class QuranResponse
        {
            public List<Surah> Data { get; set; } = new();
        }
    }
    public class Surah
    {
        public int Number { get; set; }
        public string Name { get; set; } = "";
        public string EnglishName { get; set; } = "";
        public int NumberOfAyahs { get; set; }
        
    }
}
