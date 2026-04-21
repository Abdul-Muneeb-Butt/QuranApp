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

        public async Task<List<Ayah>> GetAyahsAsync(int surahNumber)
        {
            var response = await _http.GetFromJsonAsync<AyahResponse>
            ($"https://api.alquran.cloud/v1/surah/{surahNumber}/ar.alafasy");

            return response?.Data?.Ayahs ?? new List<Ayah>();
        }
        public async Task<List<TranslationAyah>> GetTranslationAsync(int surahNumber, string language = "en.asad")
        {
            var response = await _http.GetFromJsonAsync<TranslationResponse>
            ($"http://api.alquran.cloud/v1/surah/{surahNumber}/{language}");

            return response?.Data?.Ayahs ?? new List<TranslationAyah>();
        }
    }

        public class QuranResponse
        {
            public List<Surah> Data { get; set; } = new();

        }

        public class AyahResponse
        {
            public AyahData Data { get; set; } = new();
        }

        public class AyahData
        {
            public List<Ayah> Ayahs { get; set; } = new();
        }

        public class Surah
        {
            public int Number { get; set; }
            public string Name { get; set; } = "";
            public string EnglishName { get; set; } = "";
            public int NumberOfAyahs { get; set; }

        }
    public class Ayah
    {
        public int Number { get; set; }
        public string Text { get; set; } = "";
        public int NumberInSurah { get; set; }
        public string Audio { get; set; } = "";


        public string TextWithoutBismillah
        {
            get
            {
                // Bismillah is always first 38-40 characters
                // Count characters in: بِسْمِ ٱللَّهِ ٱلرَّحْمَٰنِ ٱلرَّحِيمِ
                if (Text.Length > 38)
                {
                    return Text.Substring(39).Trim();
                }
                // If text is only Bismillah return empty
                return "";
            }
        }
    }
    public class TranslationAyah
    {
        public int NumberInSurah { get; set; }
        public string Text { get; set; } = "";
    }

    public class TranslationData
    {
        public List<TranslationAyah> Ayahs { get; set; } = new();
    }

    public class TranslationResponse
    {
        public TranslationData Data { get; set; } = new();
    }

}


