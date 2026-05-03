using System.Net.Http.Json;
namespace QuranApp.Services
{
    public class QiblaService
    {
        private readonly HttpClient _http;

        public QiblaService(HttpClient http)
        {
            _http = http;
        }
    }
}
