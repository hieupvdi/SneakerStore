using AppData.Models;
using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SneakerStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HoaDonController : Controller
    {
        public HoaDonController()
        {
            
        }
        public async Task<IActionResult> ShowAllHD()
        {
            var httpClient = new HttpClient();
            string apiURL = "https://localhost:7001/api/HoaDon/HoaDon/get-all";
            var response = await httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<HoaDonVM>>(apiData);
            return View(result);
        }



        public async Task<IActionResult> ShowAllHDCT()
        {
            var httpClient = new HttpClient();
            string apiURL = "https://localhost:7001/api/HoaDonCT/HoaDonCT/get-all";
            var response = await httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<HoaDonCTVM>>(apiData);
            return View(result);
        }

    }
}
