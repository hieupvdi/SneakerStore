using AppData.Models;
using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection.Metadata;
using System.Text;

namespace SneakerStore.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class DanhMucController : Controller
    {
        public DanhMucController()
        {
            
        }
        public async Task<IActionResult> ShowAllDM()
        {
            var httpClient = new HttpClient();
            string apiURL = "https://localhost:7001/api/DanhMuc/DanhMuc/get-all";
            var response = await httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<DanhMucVM>>(apiData);
            return View(result);
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DanhMucVM dm)
        {
            if (!ModelState.IsValid)
                return View(dm);

            var httpClient = new HttpClient();

            string apiURL = "https://localhost:7001/api/DanhMuc/DanhMuc/create";

            var json = JsonConvert.SerializeObject(dm);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllDM");
            }
            ModelState.AddModelError("", "Create Sai roi");

            return View(dm);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/DanhMuc/DanhMuc/{id}";

            var response = await httpClient.GetAsync(apiURL);

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<DanhMucVM>(apiData);
            return View(result);
        }

        public async Task<IActionResult> Edit(DanhMucVM dm)
        {
            if (!ModelState.IsValid)
                return View(dm);
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/DanhMuc/DanhMuc/update/{dm.Id}";

            var json = JsonConvert.SerializeObject(dm);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            //var content = new StringContent(JsonConvert.SerializeObject(capBacVM, Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllDM");
            }
            ModelState.AddModelError("", "Edit sai r");

            return View(dm);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/DanhMuc/DanhMuc/delete/{id}";

            var response = await httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllDM");
            }
            ModelState.AddModelError("", "Delete sai R");
            return BadRequest();
        }
    }
}
