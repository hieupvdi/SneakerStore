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
                Guid userId = Guid.Parse(userIdinSession);
                string apiURL1 = "https://localhost:7001/api/CTSanPham/CTSanPham/get-all";

                string apiURL2 = "https://localhost:7001/api/AnhSanPham/AnhSanPham/get-all";

                string apiURL3 = $"https://localhost:7001/api/User/User/{userId}";
               

                string apiURL = $"https://localhost:7001/api/GioHangCT/GioHangCT/{userIdinSession}";

                var response1 = await httpClient.GetAsync(apiURL1);
                string apiData1 = await response1.Content.ReadAsStringAsync();
                var result1 = JsonConvert.DeserializeObject<List<CTSanPhamVM>>(apiData1);
                ViewBag.CTSanPhamData = result1;

                var response2 = await httpClient.GetAsync(apiURL2);
                string apiData2 = await response2.Content.ReadAsStringAsync();
                var result2 = JsonConvert.DeserializeObject<List<AnhSanPhamVM>>(apiData2);
                ViewBag.AnhData = result2;


                var response3 = await httpClient.GetAsync(apiURL3);
                string apiData3 = await response3.Content.ReadAsStringAsync();
                var result3 = JsonConvert.DeserializeObject<UserVM>(apiData3);
                ViewBag.UserData = new List<UserVM> { result3 };


                string apiURL4 = "https://localhost:7001/api/DiaChi/DiaChi/get-all";
                var response4 = await httpClient.GetAsync(apiURL4);
				string apiData4 = await response4.Content.ReadAsStringAsync();				
			    var result4 = JsonConvert.DeserializeObject<List<DiaChiVM>>(apiData4);
			    ViewBag.DiaChiData = result4;


                string apiURL5 = "https://localhost:7001/api/Voucher/Voucher/get-all";
                var response5 = await httpClient.GetAsync(apiURL5);
                string apiData5 = await response5.Content.ReadAsStringAsync();
                var result5 = JsonConvert.DeserializeObject<List<VoucherVM>>(apiData5);
                ViewBag.VoucherData = result5;


                var response = await httpClient.GetAsync(apiURL);
                string apiData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<GioHangCTVM>>(apiData);

                return View(result);

            }

            return RedirectToAction("DangNhap", "Acc");

        }





        public async Task<IActionResult> CreateGH(Guid idctsp,decimal giaban)
        {
            var httpClient = new HttpClient();

            var userIdinSession = HttpContext.Session.GetString("userId");
            if (string.IsNullOrEmpty(userIdinSession)) return RedirectToAction("DangNhap", "Acc");
            Guid userId = Guid.Parse(userIdinSession);

            // Tạo giỏ hàng mới
            var ApiURL = "https://localhost:7001/api/GioHang/GioHang/create";
            var gh = new GioHangVM
            {
                IdUser = userId,
                MoTa = "Người dùng",
                TrangThai = 1,
            };

            var json = JsonConvert.SerializeObject(gh);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(ApiURL, content);



            // Lấy giỏ hàng chi tiết
            // Tạo giỏ hàng chi tiết mới
            var newgh = new GioHangCTVM
            {
                IdUser = userId,
                SoLuong = 0,
                DonGia = giaban,
                IdCTSP = idctsp,
                TrangThai = 1,
            };
            string apiURL1 = "https://localhost:7001/api/GioHangCT/GioHangCT/get-all";
            var response1 = await httpClient.GetAsync(apiURL1);
            string apiData1 = await response1.Content.ReadAsStringAsync();
            var result1 = JsonConvert.DeserializeObject<List<GioHangCTVM>>(apiData1);
            List<GioHangCTVM> ghct=result1.Where(c=>c.IdUser == userId).ToList();
            if (ghct.Any(c=>c.IdUser==userId&&c.IdCTSP==idctsp))
            {

                string apiURL4 = $"https://localhost:7001/api/GioHangCT/GioHangCT/ById?iduser={userId}&idctsp={idctsp}";
                var response4 = await httpClient.GetAsync(apiURL4);
                string apiData4 = await response4.Content.ReadAsStringAsync();
                var result4 = JsonConvert.DeserializeObject<GioHangCTVM>(apiData4);

                newgh.Id = result4.Id;
                newgh.SoLuong=result4.SoLuong+1;
           


                string apiURL2 = $"https://localhost:7001/api/GioHangCT/GioHangCT/update/{result4.Id}";

                var json2 = JsonConvert.SerializeObject(newgh);
                var content2 = new StringContent(json2, Encoding.UTF8, "application/json");

                var response2 = await httpClient.PutAsync(apiURL2, content2);
                if (response2.IsSuccessStatusCode)
                {
                    return RedirectToAction("ShowAllGHCT");
                }
                return BadRequest();
            }
            else
            {

                newgh.SoLuong = 1;  

                // Nếu sản phẩm chưa tồn tại trong giỏ hàng, thêm mới
                var ApiURL3 = "https://localhost:7001/api/GioHangCT/GioHangCT/create";
                var json3 = JsonConvert.SerializeObject(newgh);
                var content3 = new StringContent(json3, Encoding.UTF8, "application/json");
                var ctghApiResponse3 = await httpClient.PostAsync(ApiURL3, content3);

                if (ctghApiResponse3.IsSuccessStatusCode)
                {
                    return RedirectToAction("ShowAllGHCT");
                }
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
