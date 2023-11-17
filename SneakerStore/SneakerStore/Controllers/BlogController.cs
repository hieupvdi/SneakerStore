using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using X.PagedList;

namespace SneakerStore.Controllers
{
    public class BlogController : Controller
    {
        public async Task<IActionResult> ShowAllBlog(int page)
        {
            var httpClient = new HttpClient();
            string apiURL = "https://localhost:7001/api/Blog/Blog/get-all";
            var response = await httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<BlogVM>>(apiData);
            page = page < 1 ? 1 : page;
            int pagesize = 6;
            var blog = result.ToPagedList(page, pagesize);
            return View(blog);
        }
        [HttpGet]
        public async Task<IActionResult> DetailBlogs(Guid idblog)
        {
            var httpClient = new HttpClient();

            string apiURL = $"https://localhost:7001/api/blog/blog/{idblog}";
            var response = await httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<BlogVM>(apiData);

            return View(result);
        }
    }
}
