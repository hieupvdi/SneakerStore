using AppData.Models;
using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace SneakerStore.Controllers
{
    public class GioHangController : Controller
    {
        public async Task<IActionResult> ShowAllGHCT()
        {

            var httpClient = new HttpClient();
            
            var userIdinSession = HttpContext.Session.GetString("userId");
         
       
			if (!string.IsNullOrEmpty(userIdinSession))
			{

                string apiURL1 = "https://localhost:7001/api/CTSanPham/CTSanPham/get-all";

                string apiURL2 = "https://localhost:7001/api/AnhSanPham/AnhSanPham/get-all";

                string apiURL = $"https://localhost:7001/api/GioHangCT/GioHangCT/{userIdinSession}";







                var response1 = await httpClient.GetAsync(apiURL1);
                string apiData1 = await response1.Content.ReadAsStringAsync();
                var result1 = JsonConvert.DeserializeObject<List<CTSanPhamVM>>(apiData1);

                var response2 = await httpClient.GetAsync(apiURL2);
                string apiData2 = await response2.Content.ReadAsStringAsync();
                var result4 = JsonConvert.DeserializeObject<List<AnhSanPhamVM>>(apiData2);

                var response = await httpClient.GetAsync(apiURL);
                string apiData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<GioHangCTVM>>(apiData);

                ViewBag.CTSanPhamData = result1;
                ViewBag.AnhData = result4;
                return View(result);

            }

            return RedirectToAction("DangNhap", "Acc");

        }


   

    
        public async Task<IActionResult> CreateGH(Guid idctsp)
        {

			var userIdinSession = HttpContext.Session.GetString("userId");
			if (string.IsNullOrEmpty(userIdinSession)) return RedirectToAction("DangNhap", "Acc");

			Guid userId = Guid.Parse(userIdinSession);

			var httpClient = new HttpClient();

			var ApiURL = "https://localhost:7001/api/GioHang/GioHang/create";


			var gh= new GioHangVM
			{
				
				IdUser = userId,
				MoTa = "Người dùng",		
				TrangThai = 1,
			};

			var json = JsonConvert.SerializeObject(gh);
			var content = new StringContent(json, Encoding.UTF8, "application/json");
			var Response = await httpClient.PostAsync(ApiURL, content);


			var ApiURL1 = "https://localhost:7001/api/GioHangCT/GioHangCT/create";

		
			var ghct = new GioHangCTVM
			{
				Id = Guid.NewGuid(),
				IdUser = userId,
				SoLuong = 1,
				DonGia = 1,
				IdCTSP = idctsp,
				TrangThai = 1,
			};

			var json1 = JsonConvert.SerializeObject(ghct);
			var content1 = new StringContent(json1, Encoding.UTF8, "application/json");
			var ctghApiResponse = await httpClient.PostAsync(ApiURL1, content1);
			if (ctghApiResponse.IsSuccessStatusCode)
			{
				return RedirectToAction("ShowAllGHCT");
			}
			return BadRequest();
		}






		public async Task<IActionResult> Delete(Guid id)
		{
			var httpClient = new HttpClient();
			string apiURL = $"https://localhost:7001/api/GioHangCT/GioHangCT/delete/{id}";

			var response = await httpClient.DeleteAsync(apiURL);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("ShowAllGHCT");
			}
			ModelState.AddModelError("", "Delete sai R");
			return BadRequest();
		}

	}
}
