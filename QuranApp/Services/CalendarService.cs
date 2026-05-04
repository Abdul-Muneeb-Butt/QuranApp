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

        public async Task<List<CalendarDay>?> GetHijriMonthAsync(int month, int year)
        {
            var response = await _http.GetFromJsonAsync<CalendarResponse>
            ($"http://api.aladhan.com/v1/hToGCalendar/{month}/{year}");
            return response?.Data;
        }

        public async Task<List<CalendarDay>?> GetGregorianMonthAsync(int month, int year)
        {
            var response = await _http.GetFromJsonAsync<CalendarResponse>
            ($"http://api.aladhan.com/v1/gToHCalendar/{month}/{year}");
            return response?.Data;
        }
    }

    public class CalendarResponse
    {
        public List<CalendarDay>? Data { get; set; }
    }

    public class CalendarDay
    {
        public GregorianInfo? Gregorian { get; set; }
        public HijriInfo? Hijri { get; set; }
    }

    public class GregorianInfo
    {
        public string Day { get; set; } = "";
        public string Year { get; set; } = "";
        public GregorianMonthInfo? Month { get; set; }
        public WeekdayInfo? Weekday { get; set; }
    }

    public class GregorianMonthInfo
    {
        public int Number { get; set; }
        public string En { get; set; } = "";
    }

    public class HijriInfo
    {
        public string Day { get; set; } = "";
        public string Year { get; set; } = "";
        public HijriMonthInfo? Month { get; set; }
        public WeekdayInfo? Weekday { get; set; }
        public List<string>? Holidays { get; set; }
    }

    public class HijriMonthInfo
    {
        public int Number { get; set; }
        public string En { get; set; } = "";
        public string Ar { get; set; } = "";
    }

    public class WeekdayInfo
    {
        public string En { get; set; } = "";
    }
}