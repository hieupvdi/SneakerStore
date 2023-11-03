using AppData.Models;
using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace SneakerStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        public UserController()
        {
            
        }
        public async Task<IActionResult> ShowAllUser()
        {
            var httpClient = new HttpClient();
            string apiURL = "https://localhost:7001/api/User/User/get-all";
            var response = await httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<UserVM>>(apiData);
            return View(result);
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserVM us)
        {
            //if (!ModelState.IsValid)
            //    return View(cv);

            var httpClient = new HttpClient();

            string apiURL = "https://localhost:7001/api/User/User/create";

            var json = JsonConvert.SerializeObject(us);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllUser");
            }
            ModelState.AddModelError("", "Create Sai roi");

            return View(us);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/User/User/{id}";

            var response = await httpClient.GetAsync(apiURL);

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<UserVM>(apiData);
            return View(result);
        }

        public async Task<IActionResult> Edit(UserVM us)
        {
            if (!ModelState.IsValid) return View(us);

            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/User/User/update/{us.Id}";

            var json = JsonConvert.SerializeObject(us);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllUser");
            }
            ModelState.AddModelError("", "Edit sai r");

            return View(us);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/User/User/delete/{id}";

            var response = await httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllUser");
            }
            ModelState.AddModelError("", "Delete sai R");
            return BadRequest();
        }
    }
}
