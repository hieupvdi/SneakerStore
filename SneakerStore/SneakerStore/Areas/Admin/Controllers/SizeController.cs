using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace SneakerStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SizeController : Controller
    {
        public SizeController()
        {
            
        }
        public async Task<IActionResult> ShowAllSize()
        {
            var httpClient = new HttpClient();
            string apiURL = "https://localhost:7001/api/Size/Size/get-all";
            var response = await httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<SizeVM>>(apiData);
            return View(result);
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SizeVM s)
        {
            //if (!ModelState.IsValid)
            //    return View(cv);

            var httpClient = new HttpClient();

            string apiURL = "https://localhost:7001/api/Size/Size/create";

            var json = JsonConvert.SerializeObject(s);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllSize");
            }
            ModelState.AddModelError("", "Create Sai roi");

            return View(s);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/Size/Size/{id}";

            var response = await httpClient.GetAsync(apiURL);

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<SizeVM>(apiData);
            return View(result);
        }

        public async Task<IActionResult> Edit(SizeVM s)
        {
            if (!ModelState.IsValid) return View(s);

            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/Size/Size/update/{s.Id}";

            var json = JsonConvert.SerializeObject(s);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllSize");
            }
            ModelState.AddModelError("", "Edit sai r");

            return View(s);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/Size/Size/delete/{id}";

            var response = await httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllSize");
            }
            ModelState.AddModelError("", "Delete sai R");
            return BadRequest();
        }
    }
}
