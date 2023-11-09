using AppData.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol.Plugins;
using System.Text;

namespace SneakerStore.Controllers
{
	public class AccController : Controller
	{

		public AccController() {
			
		}
		public async Task<IActionResult> DangNhap()
		{
			return View();

        }

		[HttpPost]


		public async Task<IActionResult> DangNhap(string TenTaiKhoan, string MatKhau)
		{
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/User/User/DangNhap?TenTaiKhoan={TenTaiKhoan}&MatKhau={MatKhau}";
            var response = await httpClient.PostAsync(apiURL, new StringContent(""));

            if (response.IsSuccessStatusCode)
            {
                var apiData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<string>(apiData);
                HttpContext.Session.SetString("userId", result);
                return RedirectToAction("Index","Home");
            }
            ModelState.AddModelError("", "Đăng nhập k thành công");
            return View();

        }
	

		public async Task<IActionResult> DangKy(string Email, string TenTaiKhoan, string MatKhau)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/User/User/create";
            var us = new UserVM
            {
                IdCV = new Guid("e26fa84e-3019-4a14-862f-9fafc6014dfe"),
                HoTen = "Chưa Cập Nhập",
                Url = "/images/avta_tr.jpg",
                Email = Email,
                TenTaiKhoan = TenTaiKhoan,
                MatKhau = MatKhau,
                SDT = 0,
                GioiTinh = 0,
                SoDiem = 0,
                TrangThai = 1,

            };
            var json = JsonConvert.SerializeObject(us);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("DangNhap", "Acc");
            }
            ModelState.AddModelError("", "Đăng ký k thành công");

            return View("DangNhap");


        }


        public IActionResult DangXuat()
        {
            HttpContext.Session.Remove("userId");
            return RedirectToAction("Index","Home");
        }







    }
}
