using AppData.Models;
using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace SneakerStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DeGiayController : Controller
    {
        public DeGiayController()
        {
            
        }
        public async Task<IActionResult> ShowAllDG()
        {
            var httpClient = new HttpClient();
            string apiURL = "https://localhost:7001/api/DeGiay/DeGiay/get-all";
            var response = await httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<DeGiayVM>>(apiData);
            return View(result);
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DeGiayVM dg)
        {
            if (!ModelState.IsValid)
                return View(dg);

            var httpClient = new HttpClient();

            string apiURL = "https://localhost:7001/api/DeGiay/DeGiay/create";

            var json = JsonConvert.SerializeObject(dg);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllDG");
            }
            ModelState.AddModelError("", "Create Sai roi");

            return View(dg);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/DeGiay/DeGiay/{id}";

            var response = await httpClient.GetAsync(apiURL);

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<DeGiayVM>(apiData);
            return View(result);
        }

        public async Task<IActionResult> Edit(DeGiayVM dg)
        {
            if (!ModelState.IsValid) 
                return View(dg);

            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/DeGiay/DeGiay/update/{dg.Id}";

            var json = JsonConvert.SerializeObject(dg);
            var content = new StringContent(json, Encoding.UTF8, "application/json");       

            var response = await httpClient.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllDG");
            }
            ModelState.AddModelError("", "Edit sai r");

            return View(dg);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/DeGiay/DeGiay/delete/{id}";

            var response = await httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllDG");
            }
            ModelState.AddModelError("", "Delete sai R");
            return BadRequest();
        }
    }
}
