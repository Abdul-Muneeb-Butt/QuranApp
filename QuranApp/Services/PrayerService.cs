
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

    }
}
