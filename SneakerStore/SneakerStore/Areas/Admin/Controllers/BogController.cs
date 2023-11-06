using AppData.Models;
using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace SneakerStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BogController : Controller
    {
        public BogController()
        {
            
        }
        public async Task<IActionResult> ShowAllBog()
        {
            var httpClient = new HttpClient();
            string apiURL = "https://localhost:7001/api/Bog/Bog/get-all";
            var response = await httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<BogVM>>(apiData);
            return View(result);
        }




        public async Task<IActionResult> Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Bog bog, IFormFile UrlAnh)
        {
            if (UrlAnh != null && UrlAnh.Length > 0)
            {
                var fileName = Path.GetFileName(UrlAnh.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", UrlAnh.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    UrlAnh.CopyTo(stream);
                }
                // Lưu đường dẫn đến ảnh vào đối tượng User
                bog.IdUser = new Guid("4e80228c-98ec-4cd0-ab99-8027922bd49e");
                bog.UrlAnh = "/images/" + fileName;
                bog.NgayTao = DateTime.Now;

                //if (!ModelState.IsValid)
                //    return View(cv);

                var httpClient = new HttpClient();

                string apiURL = "https://localhost:7001/api/Bog/Bog/create";

                var json = JsonConvert.SerializeObject(bog);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(apiURL, content);
                return RedirectToAction("ShowAllBog");



            }
            return BadRequest();
        }



        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {

            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/Bog/Bog/{id}";

            var response = await httpClient.GetAsync(apiURL);

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<BogVM>(apiData);
            return View(result);
        }

        public async Task<IActionResult> Edit(BogVM bog, IFormFile UrlAnh)
        {
            if (UrlAnh != null && UrlAnh.Length > 0)
            {
                var fileName = Path.GetFileName(UrlAnh.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", UrlAnh.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    UrlAnh.CopyTo(stream);
                }
                // Lưu đường dẫn đến ảnh vào đối tượng User

                bog.UrlAnh = "/images/" + fileName;
                //if (!ModelState.IsValid) return View(bog);

                var httpClient = new HttpClient();
                string apiURL = $"https://localhost:7001/api/Bog/Bog/update/{bog.Id}";

                var json = JsonConvert.SerializeObject(bog);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PutAsync(apiURL, content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("ShowAllBog");
                }
                ModelState.AddModelError("", "Edit sai r");
            }

            return BadRequest();
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/Bog/Bog/delete/{id}";

            var response = await httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllBog");
            }
            ModelState.AddModelError("", "Delete sai R");
            return BadRequest();
        }
    }
}
