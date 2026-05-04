using System.Net.Http.Json;

namespace QuranApp.Services
{
    public class CalendarService
    {
        private readonly HttpClient _http;

        public CalendarService(HttpClient http)
        {
            _http = http;
        }

    }
}
