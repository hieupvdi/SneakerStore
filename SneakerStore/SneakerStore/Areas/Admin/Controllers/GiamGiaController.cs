using AppData.Models;
using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace SneakerStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GiamGiaController : Controller
    {
        public GiamGiaController()
        {
            
        }
        public async Task<IActionResult> ShowAllGG()
        {
            var httpClient = new HttpClient();
            string apiURL = "https://localhost:7001/api/GiamGia/GiamGia/get-all";
            var response = await httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<GiamGiaVM>>(apiData);
            return View(result);
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GiamGiaVM gg)
        {
            if (!ModelState.IsValid)
                return View(gg);

            var httpClient = new HttpClient();

            string apiURL = "https://localhost:7001/api/GiamGia/GiamGia/create";

            var json = JsonConvert.SerializeObject(gg);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllGG");
            }
            ModelState.AddModelError("", "Create Sai roi");

            return View(gg);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/GiamGia/GiamGia/{id}";

            var response = await httpClient.GetAsync(apiURL);

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<GiamGiaVM>(apiData);
            return View(result);
        }

        public async Task<IActionResult> Edit(GiamGiaVM gg)
        {
            if (!ModelState.IsValid) 
                return View(gg);

            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/GiamGia/GiamGia/update/{gg.Id}";

            var json = JsonConvert.SerializeObject(gg);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllGG");
            }
            ModelState.AddModelError("", "Edit sai r");

            return View(gg);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/GiamGia/GiamGia/delete/{id}";

            var response = await httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllGG");
            }
            ModelState.AddModelError("", "Delete sai R");
            return BadRequest();
        }
    }
}
