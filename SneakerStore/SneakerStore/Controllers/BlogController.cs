using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SneakerStore.Controllers
{
	public class BlogController : Controller
	{
		public async Task<IActionResult> ShowAllBlog()
		{
			var httpClient = new HttpClient();
			string apiURL = "https://localhost:7001/api/Blog/Blog/get-all";
			var response = await httpClient.GetAsync(apiURL);
			string apiData = await response.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<List<BlogVM>>(apiData);
			return View(result);
		}

	}
}
