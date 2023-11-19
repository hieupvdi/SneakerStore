using AppData.Models;
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


		public async Task<IActionResult> DangNhap(string TenTaiKhoan,string MatKhau)
		{
           
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/User/User/DangNhap?TenTaiKhoan={TenTaiKhoan}&MatKhau={MatKhau}";
            var response = await httpClient.PostAsync(apiURL, new StringContent(""));

            if (response.IsSuccessStatusCode)
            {
                var apiData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<string>(apiData);



                string usapiURL = $"https://localhost:7001/api/User/User/{result}";

                var usresponse = await httpClient.GetAsync(usapiURL);

                string usapiData = await usresponse.Content.ReadAsStringAsync();
                var usresult = JsonConvert.DeserializeObject<UserVM>(usapiData);

                if (usresult.ChucVu== "Người Dùng")
                {
                    HttpContext.Session.SetString("userId", result);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    HttpContext.Session.SetString("userId", result);
                    return RedirectToAction("ThongKe", "ThongKe", new { area = "Admin" });
                }
                
            }
            ModelState.AddModelError("", "Đăng nhập k thành công");
            return View();

        }
        public async Task<IActionResult> DangKy()
        { 
             return View();
        }

        [HttpPost]
        public async Task<IActionResult> DangKy(UserVM user)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/User/User/create";
            var us = new UserVM
            {
                IdCV = new Guid("e26fa84e-3019-4a14-862f-9fafc6014dfe"),
                HoTen = "Chưa Cập Nhập",
                Url = "/images/avta_tr.jpg",
                Email = user.Email,
                TenTaiKhoan = user.TenTaiKhoan,
                MatKhau = user.MatKhau,
                SDT = "Chưa Cập Nhập",
                GioiTinh = 2,          
                TrangThai = 1,

            };
            
            var json = JsonConvert.SerializeObject(us);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Đăng Ký thành công");
                //return RedirectToAction("DangNhap", "Acc");
            }
			ModelState.AddModelError("", "Đăng Ký k thành công");
            return View(us);


        }


        public IActionResult DangXuat()
        {
            HttpContext.Session.Remove("userId");
            return RedirectToAction("Index","Home");
        }


        public async Task<IActionResult> ShowACC()
        {
            var httpClient = new HttpClient();
            var userIdinSession = HttpContext.Session.GetString("userId");


            if (!string.IsNullOrEmpty(userIdinSession))
            {
                Guid userId = Guid.Parse(userIdinSession);
                ViewBag.UserIdData = userId;
                string DCApiURL = "https://localhost:7001/api/DiaChi/DiaChi/get-all";
                var DCresponse = await httpClient.GetAsync(DCApiURL);
                string DCapiData = await DCresponse.Content.ReadAsStringAsync();
                var DCresult = JsonConvert.DeserializeObject<List<DiaChiVM>>(DCapiData);
                ViewBag.DiaChiDaTe = DCresult;


                string VoApiURL = "https://localhost:7001/api/Voucher/Voucher/get-all";
                var Voresponse = await httpClient.GetAsync(VoApiURL);
                string VoapiData = await Voresponse.Content.ReadAsStringAsync();
                var Voresult = JsonConvert.DeserializeObject<List<VoucherVM>>(VoapiData);
                ViewBag.VouCherDaTe = Voresult;


                string apiURL3 = $"https://localhost:7001/api/User/User/{userId}";
            var response3 = await httpClient.GetAsync(apiURL3);
            string apiData3 = await response3.Content.ReadAsStringAsync();
            var result3 = JsonConvert.DeserializeObject<UserVM>(apiData3);
                return View(result3);

            }

            return RedirectToAction("DangNhap", "Acc");
        }


        public async Task<IActionResult> EditAcc(UserVM us, IFormFile Url)
        {

            var httpClient = new HttpClient();

            if (Url != null && Url.Length > 0)
            {
                var fileName = Path.GetFileName(Url.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", Url.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Url.CopyTo(stream);
                }
              
                //if (!ModelState.IsValid) return View(us);
                var user = new UserVM
                {
                    Id= us.Id,
                    IdCV = new Guid("e26fa84e-3019-4a14-862f-9fafc6014dfe"),
                    HoTen = us.HoTen,
                    Url = "/images/" + fileName,
                    Email = us.Email,                 
                    MatKhau = us.MatKhau,
                    SDT = us.SDT,
                    GioiTinh = us.GioiTinh,
                    TrangThai = 1,

                };

                string apiURL = $"https://localhost:7001/api/User/User/update/{us.Id}";

                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PutAsync(apiURL, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("ShowACC","Acc");
                }
                ModelState.AddModelError("", "Edit sai r");

                return View();


            }
            return View();
        }

    }
}
