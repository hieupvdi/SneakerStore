using AppData.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SneakerStore.Controllers
{
	public class SanPhamController : Controller
	{
		[HttpGet]
		public async Task<IActionResult> ShowAllSanPham()
		{
			var httpClient = new HttpClient(); // Tại 1 httpClient để call(gọi) API
			string apiURL = "https://localhost:7001/api/CTSanPham/CTSanPham/get-all";
			// Sau khi có URL thì thực hiện việc lấy dữ liệu trả về từ nó

			var response = await httpClient.GetAsync(apiURL); // Lấy kết quả
															  // Đọc ra string Json
			string apiData = await response.Content.ReadAsStringAsync();
			// Lấy kết quả thu được bằng cách bóc dữ liệu Json
			var result = JsonConvert.DeserializeObject<List<CTSanPhamVM>>(apiData);
			return View(result);
		}

	}
}
