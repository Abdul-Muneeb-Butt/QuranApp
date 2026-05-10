using System.Net.Http.Json;

namespace QuranApp.Services
{
    public class PrayerService
    {
        private readonly HttpClient _http;

        public PrayerService(HttpClient http)
        {
            _http = http;
        }

        public async Task<PrayerTimes?> GetPrayerTimesAsync(string city, string country)
        {
            var response = await _http.GetFromJsonAsync<PrayerApiResponse>
            ($"http://api.aladhan.com/v1/timingsByCity?city={city}&country={country}&method=2");
            return response?.Data?.Timings;
        }

        public async Task<PrayerHijriInfo?> GetHijriDateAsync()
        {
            var today = DateTime.Now.ToString("dd-MM-yyyy");
            var response = await _http.GetFromJsonAsync<HijriApiResponse>
            ($"http://api.aladhan.com/v1/gToH?date={today}");
            return response?.Data?.Hijri;
        }
    }

    public class PrayerApiResponse
    {
        public PrayerData? Data { get; set; }
    }

    public class PrayerData
    {
        public PrayerTimes? Timings { get; set; }
    }

    public class PrayerTimes
    {
        public string Fajr { get; set; } = "";
        public string Sunrise { get; set; } = "";
        public string Dhuhr { get; set; } = "";
        public string Asr { get; set; } = "";
        public string Maghrib { get; set; } = "";
        public string Isha { get; set; } = "";
    }

    public class HijriApiResponse
    {
        public HijriApiData? Data { get; set; }
    }

    public class HijriApiData
    {
        public PrayerHijriInfo? Hijri { get; set; }
    }

    public class PrayerHijriInfo
    {
        public string Day { get; set; } = "";
        public string Year { get; set; } = "";
        public PrayerHijriWeekday? Weekday { get; set; }
        public PrayerHijriMonth? Month { get; set; }
    }

    public class PrayerHijriWeekday
    {
        public string En { get; set; } = "";
    }

    public class PrayerHijriMonth
    {
        public string En { get; set; } = "";
    }
}