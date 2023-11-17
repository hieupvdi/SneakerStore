using AppData.Models;
using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SneakerStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public BlogController()
        {
            
        }
        public async Task<IActionResult> ShowAllBlog()
        {
            var httpClient = new HttpClient();
            string apiURL = "https://localhost:7001/api/Blog/Blog/get-all";
            var response = await httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<BlogVM>>(apiData);
            return View(result);
        }




        public async Task<IActionResult> Create()
        {

            return View();
        }

        [HttpPost]
     
        public async Task<IActionResult> Create(BlogVM blog, IFormFile UrlAnh)
        {
            if (!ModelState.IsValid)
                return View(blog);

            var userIdinSession = HttpContext.Session.GetString("userId");
            if (string.IsNullOrEmpty(userIdinSession)) return RedirectToAction("DangNhap", "Acc");
            Guid userId = Guid.Parse(userIdinSession);
            if (UrlAnh != null && UrlAnh.Length > 0)
            {
                var fileName = Path.GetFileName(UrlAnh.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", UrlAnh.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    UrlAnh.CopyTo(stream);
                }
                // Lưu đường dẫn đến ảnh vào đối tượng User
                blog.IdUser = userId;
                blog.UrlAnh = "/images/" + fileName;
                blog.NgayTao = DateTime.Now;

                

         
                var httpClient = new HttpClient();

                string apiURL = "https://localhost:7001/api/Blog/Blog/create";

                var json = JsonConvert.SerializeObject(blog);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(apiURL, content);
                return RedirectToAction("ShowAllBlog");



            }
            return BadRequest();
        }



        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {

            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/Blog/Blog/{id}";

            var response = await httpClient.GetAsync(apiURL);

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<BlogVM>(apiData);
            return View(result);
        }

        public async Task<IActionResult> Edit(BlogVM blog, IFormFile UrlAnh)
        {
            if (!ModelState.IsValid)
                return View(blog);
            var userIdinSession = HttpContext.Session.GetString("userId");
            Guid userId = Guid.Parse(userIdinSession);
            if (UrlAnh != null && UrlAnh.Length > 0)
            {
                var fileName = Path.GetFileName(UrlAnh.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", UrlAnh.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    UrlAnh.CopyTo(stream);
                }
                // Lưu đường dẫn đến ảnh vào đối tượng User

                blog.UrlAnh = "/images/" + fileName;
                blog.IdUser = userId;

         
                var httpClient = new HttpClient();
                string apiURL = $"https://localhost:7001/api/Blog/Blog/update/{blog.Id}";

                var json = JsonConvert.SerializeObject(blog);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PutAsync(apiURL, content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("ShowAllBlog");
                }
                ModelState.AddModelError("", "Edit sai r");
            }

            return BadRequest();
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/Blog/Blog/delete/{id}";

            var response = await httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllBlog");
            }
            ModelState.AddModelError("", "Delete sai R");
            return BadRequest();
        }
    }
}
