using AppData.Models;
using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace SneakerStore.Controllers
{
    public class DiaChiController : Controller
    {

        public async Task<IActionResult> CreateDiachi(string diachi)
        {
            var userIdinSession = HttpContext.Session.GetString("userId");
            if (string.IsNullOrEmpty(userIdinSession)) return RedirectToAction("DangNhap", "Acc");

            Guid userId = Guid.Parse(userIdinSession);
            var dc = new DiaChiVM
            {
                Id=Guid.NewGuid(),
                IdUser = userId,
                Ten = diachi,
                TrangThai = 1,
            };
                 if (!ModelState.IsValid)
                    return View(dc);
            var httpClient = new HttpClient();

            string apiURL = "https://localhost:7001/api/DiaChi/DiaChi/create";

            var json = JsonConvert.SerializeObject(dc);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllGHCT","GioHang");
            }
            ModelState.AddModelError("", "Create Sai roi");

            return View(dc);
        }











        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/DiaChi/DiaChi/{id}";

            var response = await httpClient.GetAsync(apiURL);

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<DiaChiVM>(apiData);
            return View(result);
        }

        public async Task<IActionResult> Edit(DiaChiVM dc)
        {
            if (!ModelState.IsValid)
                return View(dc);

            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/DiaChi/DiaChi/update/{dc.Id}";

            var json = JsonConvert.SerializeObject(dc);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowACC","Acc");
            }
            ModelState.AddModelError("", "Edit sai r");

            return View(dc);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/DiaChi/DiaChi/delete/{id}";

            var response = await httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowACC","Acc");
            }
            ModelState.AddModelError("", "Delete sai R");
            return BadRequest();
        }
    }
}
