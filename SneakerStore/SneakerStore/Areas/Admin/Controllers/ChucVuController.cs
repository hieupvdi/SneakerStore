using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace SneakerStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChucVuController : Controller
    {
        public ChucVuController()
        {
            
        }

        public async Task<IActionResult> ShowCV()
        {
            var httpClient = new HttpClient();
            string apiURL = "https://localhost:7001/api/ChucVu/ChucVu/get-all";
            var response = await httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<ChucVuVM>>(apiData);
            return View(result);
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ChucVuVM cv)
        {
            //if (!ModelState.IsValid)
            //    return View(cv);

            var httpClient = new HttpClient();

            string apiURL = "https://localhost:7001/api/ChucVu/ChucVu/create";

            var json = JsonConvert.SerializeObject(cv);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowCV");
            }
            ModelState.AddModelError("", "Create Sai roi");

            return View(cv);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/ChucVu/ChucVu/{id}";

            var response = await httpClient.GetAsync(apiURL);

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ChucVuVM>(apiData);
            return View(result);
        }

        public async Task<IActionResult> Edit(ChucVuVM cv)
        {
            if (!ModelState.IsValid) return View(cv);

            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/ChucVu/ChucVu/update/{cv.Id}";

            var json = JsonConvert.SerializeObject(cv);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            //var content = new StringContent(JsonConvert.SerializeObject(capBacVM, Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowCV");
            }
            ModelState.AddModelError("", "Edit sai r");

            return View(cv);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/ChucVu/ChucVu/delete/{id}";

            var response = await httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowCV");
            }
            ModelState.AddModelError("", "Delete sai R");
            return BadRequest();
        }
    }
}
