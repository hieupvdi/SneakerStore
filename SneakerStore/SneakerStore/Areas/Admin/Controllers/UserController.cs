using AppData.Models;
using AppData.Services;
using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
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
            var httpClient = new HttpClient();
            string apiURL1 = "https://localhost:7001/api/ChucVu/ChucVu/get-all";
            var response1 = await httpClient.GetAsync(apiURL1);
            string apiData1 = await response1.Content.ReadAsStringAsync();
            var result1 = JsonConvert.DeserializeObject<List<ChucVuVM>>(apiData1);

            string apiURL2 = "https://localhost:7001/api/DiaChi/DiaChi/get-all";
            var response2 = await httpClient.GetAsync(apiURL2);
            string apiData2 = await response2.Content.ReadAsStringAsync();
            var result2 = JsonConvert.DeserializeObject<List<DiaChiVM>>(apiData2);

            ViewBag.ChucVuData = result1;
            ViewBag.DiaChiData = result2;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserVM us, IFormFile Url)
        {
            var httpClient = new HttpClient();
            string apiURL1 = "https://localhost:7001/api/ChucVu/ChucVu/get-all";
            var response1 = await httpClient.GetAsync(apiURL1);
            string apiData1 = await response1.Content.ReadAsStringAsync();
            var result1 = JsonConvert.DeserializeObject<List<ChucVuVM>>(apiData1);

            string apiURL2 = "https://localhost:7001/api/DiaChi/DiaChi/get-all";
            var response2 = await httpClient.GetAsync(apiURL2);
            string apiData2 = await response2.Content.ReadAsStringAsync();
            var result2 = JsonConvert.DeserializeObject<List<DiaChiVM>>(apiData2);

            ViewBag.ChucVuData = result1;
            ViewBag.DiaChiData = result2;
            // Lưu file ảnh vào thư mục "wwwroot/images"
            if (Url != null && Url.Length > 0)
            {
                var fileName = Path.GetFileName(Url.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", Url.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Url.CopyTo(stream);
                }
                // Lưu đường dẫn đến ảnh vào đối tượng User
                us.Url = "/images/" + fileName;

              

                //if (!ModelState.IsValid)
                //    return View(us);

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

            return View(us);

        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {

            var httpClient = new HttpClient();
            string apiURL1 = "https://localhost:7001/api/ChucVu/ChucVu/get-all";
            var response1 = await httpClient.GetAsync(apiURL1);
            string apiData1 = await response1.Content.ReadAsStringAsync();
            var result1 = JsonConvert.DeserializeObject<List<ChucVuVM>>(apiData1);

            string apiURL2 = "https://localhost:7001/api/DiaChi/DiaChi/get-all";
            var response2 = await httpClient.GetAsync(apiURL2);
            string apiData2 = await response2.Content.ReadAsStringAsync();
            var result2 = JsonConvert.DeserializeObject<List<DiaChiVM>>(apiData2);

            ViewBag.ChucVuData = result1;
            ViewBag.DiaChiData = result2;

            
            string apiURL = $"https://localhost:7001/api/User/User/{id}";

            var response = await httpClient.GetAsync(apiURL);

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<UserVM>(apiData);
            return View(result);
        }

        public async Task<IActionResult> Edit(UserVM us, IFormFile Url)
        {
            var httpClient = new HttpClient();
            string apiURL1 = "https://localhost:7001/api/ChucVu/ChucVu/get-all";
            var response1 = await httpClient.GetAsync(apiURL1);
            string apiData1 = await response1.Content.ReadAsStringAsync();
            var result1 = JsonConvert.DeserializeObject<List<ChucVuVM>>(apiData1);

            string apiURL2 = "https://localhost:7001/api/DiaChi/DiaChi/get-all";
            var response2 = await httpClient.GetAsync(apiURL2);
            string apiData2 = await response2.Content.ReadAsStringAsync();
            var result2 = JsonConvert.DeserializeObject<List<DiaChiVM>>(apiData2);

            ViewBag.ChucVuData = result1;
            ViewBag.DiaChiData = result2;

            if (Url != null && Url.Length > 0)
            {
                var fileName = Path.GetFileName(Url.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", Url.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Url.CopyTo(stream);
                }
                // Lưu đường dẫn đến ảnh vào đối tượng User
                us.Url = "/images/" + fileName;



                //if (!ModelState.IsValid) return View(us);


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
