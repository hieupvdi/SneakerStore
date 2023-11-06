using AppData.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SneakerStore.Controllers
{
	public class AccController : Controller
	{

		public AccController() {
			////lưu session
			//HttpContext.Session.SetString("userId", result);
			////lấy 
			//var userIdinSession = HttpContext.Session.GetString("userId");

			//Guid userId = Guid.Parse(userIdinSession);
		}
		public ActionResult DangNhap()
		{
			return View();
		}

		[HttpPost]


		public async Task<IActionResult> DangNhap(string TenTaiKhoan, string MatKhau)
		{
			var httpClient = new HttpClient();
			string apiURL = $"https://localhost:7001/api/User/User/DangNhap?{TenTaiKhoan}=qqqq&{MatKhau}=qq";

			var response = await httpClient.PostAsync(apiURL, new StringContent(""));

			if (response.IsSuccessStatusCode)
			{
				var apiData = await response.Content.ReadAsStringAsync();
				var result = JsonConvert.DeserializeObject<string>(apiData);
				HttpContext.Session.SetString("userId", result);
				return RedirectToAction("Index");
			}
			return View();



		}



	}
}
