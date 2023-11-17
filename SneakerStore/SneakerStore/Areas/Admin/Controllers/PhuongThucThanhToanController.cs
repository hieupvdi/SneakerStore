using AppData.Models;
using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection.Metadata;
using System.Text;

namespace SneakerStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PhuongThucThanhToanController : Controller
    {
        public PhuongThucThanhToanController()
        {
            
        }
        public async Task<IActionResult> ShowAllPTTT()
        {
            var httpClient = new HttpClient();
            string apiURL = "https://localhost:7001/api/PhuongThucThanhToan/PTTT/get-all";
            var response = await httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<PhuongThucThanhToanVM>>(apiData);
            return View(result);
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PhuongThucThanhToanVM pt)
        {
            if (!ModelState.IsValid)
                return View(pt);

            var httpClient = new HttpClient();

            string apiURL = "https://localhost:7001/api/PhuongThucThanhToan/PTTT/create";

            var json = JsonConvert.SerializeObject(pt);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllPTTT");
            }
            ModelState.AddModelError("", "Create Sai roi");

            return View(pt);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/PhuongThucThanhToan/PTTT/{id}";

            var response = await httpClient.GetAsync(apiURL);

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<PhuongThucThanhToanVM>(apiData);
            return View(result);
        }

        public async Task<IActionResult> Edit(PhuongThucThanhToanVM pt)
        {
            if (!ModelState.IsValid)
                return View(pt);

            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/PhuongThucThanhToan/PTTT/update/{pt.Id}";

            var json = JsonConvert.SerializeObject(pt);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllPTTT");
            }
            ModelState.AddModelError("", "Edit sai r");

            return View(pt);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/PhuongThucThanhToan/PTTT/delete/{id}";

            var response = await httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllPTTT");
            }
            ModelState.AddModelError("", "Delete sai R");
            return BadRequest();
        }
    }
}
