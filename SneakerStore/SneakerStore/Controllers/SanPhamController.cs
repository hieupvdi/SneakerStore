using AppData.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using X.PagedList;

namespace SneakerStore.Controllers
{
	public class SanPhamController : Controller
	{
		[HttpGet]
		public async Task<IActionResult> ShowAllSanPham(int page)
		{
			var httpClient = new HttpClient(); 
			string apiURL = "https://localhost:7001/api/CTSanPham/CTSanPham/get-all";
			var response = await httpClient.GetAsync(apiURL); 															  
			string apiData = await response.Content.ReadAsStringAsync();
			// Lấy kết quả thu được bằng cách bóc dữ liệu Json
			var result = JsonConvert.DeserializeObject<List<CTSanPhamVM>>(apiData);

			string apiURL1 = "https://localhost:7001/api/MauSac/MauSac/get-all";
			var response1 = await httpClient.GetAsync(apiURL1);
			string apiData1 = await response1.Content.ReadAsStringAsync();
			// Lấy kết quả thu được bằng cách bóc dữ liệu Json
			var result1 = JsonConvert.DeserializeObject<List<MauSacVM>>(apiData1);

			string apiURL2 = "https://localhost:7001/api/Size/Size/get-all";
			var response2 = await httpClient.GetAsync(apiURL2);
			string apiData2 = await response2.Content.ReadAsStringAsync();
			// Lấy kết quả thu được bằng cách bóc dữ liệu Json
			var result2 = JsonConvert.DeserializeObject<List<SizeVM>>(apiData2);


			string apiURL3 = "https://localhost:7001/api/DanhMuc/DanhMuc/get-all";
			var response3 = await httpClient.GetAsync(apiURL3);
			string apiData3 = await response3.Content.ReadAsStringAsync();
			// Lấy kết quả thu được bằng cách bóc dữ liệu Json
			var result3 = JsonConvert.DeserializeObject<List<DanhMucVM>>(apiData3);


			string apiURL4 = "https://localhost:7001/api/AnhSanPham/AnhSanPham/get-all";
			var response4 = await httpClient.GetAsync(apiURL4);
			string apiData4 = await response4.Content.ReadAsStringAsync();
			// Lấy kết quả thu được bằng cách bóc dữ liệu Json
			var result4 = JsonConvert.DeserializeObject<List<AnhSanPhamVM>>(apiData4);

            page = page < 1 ? 1 : page;
            int pagesize = 12;
            var sanpham = result.ToPagedList(page, pagesize);

            ViewBag.CTSanPhamData = sanpham;
			ViewBag.MauSacData = result1;
			ViewBag.SizeData = result2;
			ViewBag.DanhMucData = result3;
			ViewBag.AnhData = result4;
            return View();




		}



		public async Task<IActionResult> Details(Guid id)
		{

			var httpClient = new HttpClient();
			string apiURL = $"https://localhost:7001/api/CTSanPham/CTSanPham/{id}";

			var response = await httpClient.GetAsync(apiURL);

			string apiData = await response.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<CTSanPhamVM>(apiData);


			string apiURL4 = "https://localhost:7001/api/AnhSanPham/AnhSanPham/get-all";
			var response4 = await httpClient.GetAsync(apiURL4);
			string apiData4 = await response4.Content.ReadAsStringAsync();
			// Lấy kết quả thu được bằng cách bóc dữ liệu Json
			var result4 = JsonConvert.DeserializeObject<List<AnhSanPhamVM>>(apiData4);

			//ViewBag.CTSanPhamData = result;
			ViewBag.AnhData = result4;


			return View(result);
			
		}

    }
}
