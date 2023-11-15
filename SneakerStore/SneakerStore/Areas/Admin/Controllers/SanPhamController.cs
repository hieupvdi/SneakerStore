using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace SneakerStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SanPhamController : Controller
    {
        public SanPhamController()
        {
            
        }
        public async Task<IActionResult> ShowAllSP()
        {
            var httpClient = new HttpClient();
            string apiURL = "https://localhost:7001/api/SanPham/SanPham/get-all";
            var response = await httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<SanPhamVM>>(apiData);
            return View(result);
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SanPhamVM sp)
        {
            if (!ModelState.IsValid)
                return View(sp);

            var httpClient = new HttpClient();

            string apiURL = "https://localhost:7001/api/SanPham/SanPham/create";

            var json = JsonConvert.SerializeObject(sp);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllSP");
            }
            ModelState.AddModelError("", "Create Sai roi");

            return View(sp);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/SanPham/SanPham/{id}";

            var response = await httpClient.GetAsync(apiURL);

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<SanPhamVM>(apiData);
            return View(result);
        }

        public async Task<IActionResult> Edit(SanPhamVM sp)
        {
            if (!ModelState.IsValid)
                return View(sp);

            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/SanPham/SanPham/update/{sp.Id}";

            var json = JsonConvert.SerializeObject(sp);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllSP");
            }
            ModelState.AddModelError("", "Edit sai r");

            return View(sp);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/SanPham/SanPham/delete/{id}";

            var response = await httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllSP");
            }
            ModelState.AddModelError("", "Delete sai R");
            return BadRequest();
        }
    }
}
