using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace SneakerStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AnhSPController : Controller
    {
        public AnhSPController()
        {
            
        }


        public async Task<IActionResult> ShowAllAnh()
        {
            var httpClient = new HttpClient();
            string apiURL = "https://localhost:7001/api/AnhSanPham/AnhSanPham/get-all";
            var response = await httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<AnhSanPhamVM>>(apiData);
            return View(result);
        }




        public async Task<IActionResult> Create(Guid idctsp)
        {

            var anh = new AnhSanPhamVM
            {
                IdCTSP = idctsp

            };
            return View(anh);

            

        }

        [HttpPost]
        public async Task<IActionResult> Create(AnhSanPhamVM Anh, IFormFile URlAnh)
        {
            if (!ModelState.IsValid)
                return View(Anh);
            if (URlAnh != null && URlAnh.Length > 0)
            {
                var fileName = Path.GetFileName(URlAnh.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", URlAnh.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    URlAnh.CopyTo(stream);
                }
                // Lưu đường dẫn đến ảnh vào đối tượng User
               
                Anh.URlAnh = "/images/" + fileName;
               
             
              
                var httpClient = new HttpClient();

                string apiURL = "https://localhost:7001/api/AnhSanPham/AnhSanPham/create";

                var json = JsonConvert.SerializeObject(Anh);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(apiURL, content);
                if(response.IsSuccessStatusCode)
                {
                    return RedirectToAction("ShowAllQLSP", "QLSanPham");
                }
                return View();


               
            }
            return View();
        }















        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/AnhSanPham/AnhSanPham/{id}";

            var response = await httpClient.GetAsync(apiURL);

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<AnhSanPhamVM>(apiData);
            return View(result);
        }

        public async Task<IActionResult> Edit(AnhSanPhamVM Anh)
        {
            if (!ModelState.IsValid)
                return View(Anh);

            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/AnhSanPham/AnhSanPham/update/{Anh.Id}";

            var json = JsonConvert.SerializeObject(Anh);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllQLSP", "QLSanPham");
            }
            ModelState.AddModelError("", "Edit sai r");

            return View(Anh);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/AnhSanPham/AnhSanPham/delete/{id}";

            var response = await httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllQLSP", "QLSanPham");
            }
            ModelState.AddModelError("", "Delete sai R");
            return BadRequest();
        }





    }
}
