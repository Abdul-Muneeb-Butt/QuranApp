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
        public async Task<List<CalendarDay>?> GetGregorianMonthAsync(int month, int year)
        {
            var response = await _http.GetFromJsonAsync<HijriMonthResponse>
            ($"http://api.aladhan.com/v1/gToHCalendar/{month}/{year}");
            return response?.Data;
        }
    }
    public class GregorianMonth
    {
        public int Number { get; set; }
        public string En { get; set; } = "";
    }
    public class HijriDate
    {
        public string Date { get; set; } = "";
        public string Day { get; set; } = "";
        public HijriMonth? Month { get; set; }
        public string Year { get; set; } = "";
        public HijriWeekday? Weekday { get; set; }
        public List<string>? Holidays { get; set; }
    }
    public class HijriMonth
    {
        public int Number { get; set; }
        public string En { get; set; } = "";
        public string Ar { get; set; } = "";
    }
}
