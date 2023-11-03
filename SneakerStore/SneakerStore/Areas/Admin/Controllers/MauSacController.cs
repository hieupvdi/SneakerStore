using AppData.Models;
using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace SneakerStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MauSacController : Controller
    {
        public MauSacController()
        {
            
        }
        public async Task<IActionResult> ShowAllMS()
        {
            var httpClient = new HttpClient();
            string apiURL = "https://localhost:7001/api/MauSac/MauSac/get-all";
            var response = await httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<MauSacVM>>(apiData);
            return View(result);
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MauSacVM ms)
        {
            //if (!ModelState.IsValid)
            //    return View(cv);

            var httpClient = new HttpClient();

            string apiURL = "https://localhost:7001/api/MauSac/MauSac/create";

            var json = JsonConvert.SerializeObject(ms);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllMS");
            }
            ModelState.AddModelError("", "Create Sai roi");

            return View(ms);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/MauSac/MauSac/{id}";

            var response = await httpClient.GetAsync(apiURL);

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<MauSacVM>(apiData);
            return View(result);
        }

        public async Task<IActionResult> Edit(MauSacVM ms)
        {
            if (!ModelState.IsValid) return View(ms);

            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/MauSac/MauSac/update/{ms.Id}";

            var json = JsonConvert.SerializeObject(ms);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllMS");
            }
            ModelState.AddModelError("", "Edit sai r");

            return View(ms);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/MauSac/MauSac/delete/{id}";

            var response = await httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllMS");
            }
            ModelState.AddModelError("", "Delete sai R");
            return BadRequest();
        }
    }
}

