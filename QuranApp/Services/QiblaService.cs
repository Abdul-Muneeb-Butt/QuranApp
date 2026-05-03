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
        public async Task<double> GetQiblaDirectionAsync(double latitude, double longitude)
        {
            var response = await _http.GetFromJsonAsync<QiblaResponse>
            ($"http://api.aladhan.com/v1/qibla/{latitude}/{longitude}");

            return response?.Data?.Direction ?? 0;
        }
    }
}

