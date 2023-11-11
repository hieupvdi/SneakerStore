using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SneakerStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ThongKeController : Controller
    {
        public async Task<IActionResult> ThongKe(string tu_ngay, string den_ngay)
        {
            DateTime? fromDate = null;
            DateTime? toDate = null;

            if (!string.IsNullOrWhiteSpace(tu_ngay) && DateTime.TryParse(tu_ngay, out var fromDateParsed))
            {
                fromDate = fromDateParsed;
            }

            if (!string.IsNullOrWhiteSpace(den_ngay) && DateTime.TryParse(den_ngay, out var toDateParsed))
            {
                // Add one day to include the entire end day
                toDate = toDateParsed.AddDays(1);
            }

            var httpClient = new HttpClient();
            string apiURL = "https://localhost:7001/api/HoaDon/HoaDon/get-all";
            var response = await httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var allData = JsonConvert.DeserializeObject<List<HoaDonVM>>(apiData);

            // Filter the data based on the date range
            var filteredData = allData
                .Where(item => (!fromDate.HasValue || item.NgayTao >= fromDate)
                    && (!toDate.HasValue || item.NgayTao < toDate))
                .ToList();

            return View(filteredData);
        }
       


    }
}
