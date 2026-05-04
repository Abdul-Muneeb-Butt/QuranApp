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
        public async Task<HijriCalendarInfo?> GetHijriCalendarAsync(int month, int year)
        {
            var response = await _http.GetFromJsonAsync<HijriCalendarResponse>
            ($"http://api.aladhan.com/v1/hToGCalendar/{month}/{year}");
            return response?.Data?.FirstOrDefault();
        }
        public async Task<List<CalendarDay>?> GetHijriMonthAsync(int month, int year)
        {
            var response = await _http.GetFromJsonAsync<HijriMonthResponse>
            ($"http://api.aladhan.com/v1/hToGCalendar/{month}/{year}");
            return response?.Data;
        }
    }
}
