using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace SneakerStore.Controllers
{
	public class HoaDonController : Controller
	{
        public async Task<IActionResult> ShowAllHD()
        {

            var httpClient = new HttpClient();

            var userIdinSession = HttpContext.Session.GetString("userId");


            if (!string.IsNullOrEmpty(userIdinSession))
            {
                Guid userId = Guid.Parse(userIdinSession);
                string apiURL = "https://localhost:7001/api/HoaDon/HoaDon/get-all";
                ViewBag.UserId = userId;
                var response = await httpClient.GetAsync(apiURL);
                string apiData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<HoaDonVM>>(apiData);

                return View(result);

            }

            return RedirectToAction("DangNhap", "Acc");

        }




        public async Task<IActionResult> CreateHD(HoaDonVM hoadon)
        {
            //Tạo Hóa đơn
            var userIdinSession = HttpContext.Session.GetString("userId");
            if (string.IsNullOrEmpty(userIdinSession)) return RedirectToAction("DangNhap", "Acc");

            Guid userId = Guid.Parse(userIdinSession);

            var httpClient = new HttpClient();

            var ApiURL = "https://localhost:7001/api/HoaDon/HoaDon/create";
            string apiURL3 = $"https://localhost:7001/api/User/User/{userId}";

            var response3 = await httpClient.GetAsync(apiURL3);
            string apiData3 = await response3.Content.ReadAsStringAsync();
            var result3 = JsonConvert.DeserializeObject<UserVM>(apiData3);
            
            var hd = new HoaDonVM
            {
                Id=Guid.NewGuid(),
                IdUser = userId,
                IdVoucher = hoadon.IdVoucher,
                MaHD="HD1",
                NgayTao=DateTime.Now,
                NgayThanhToan=DateTime.Now,
                NgayShip=DateTime.Now,
                NgayNhan=DateTime.Now,
                NguoiNhan= result3.HoTen,
                DiaChi= hoadon.DiaChi,
                SDT= result3.SDT,
                SoDiemSD=0,
                TienShip=0,
                TongTien=0,
                TrangThai=1,


            };

            var json = JsonConvert.SerializeObject(hd);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var Response = await httpClient.PostAsync(ApiURL, content);

            if (Response.IsSuccessStatusCode)//check hóa đơn tạo thành c
            {
                //tạo Hóa đơn ct
                string gioHangApiUrl = $"https://localhost:7001/api/GioHangCT/GioHangCT/{userIdinSession}";
                var gioHangResponse = await httpClient.GetAsync(gioHangApiUrl);
                if (gioHangResponse.IsSuccessStatusCode)
                {
                   
                    string gioHangData = await gioHangResponse.Content.ReadAsStringAsync();
                    var gioHangDataList = JsonConvert.DeserializeObject<List<GioHangCTVM>>(gioHangData);


                    foreach (var gioHangCT in gioHangDataList)
                    {
                        string hoaDonApiUrl = "https://localhost:7001/api/HoaDonCT/HoaDonCT/create";
                        var hdct = new HoaDonCTVM
                        {
                            Id = Guid.NewGuid(),
                            IdHD = hd.Id,
                            IdCTSP = gioHangCT.IdCTSP,
                            SoLuong = gioHangCT.SoLuong,
                            DonGia = gioHangCT.DonGia,
                            TrangThai = 1,
                        };
                        var json1 = JsonConvert.SerializeObject(hdct);
                        var content1 = new StringContent(json1, Encoding.UTF8, "application/json");
                        var createHoaDonResponse = await httpClient.PostAsync(hoaDonApiUrl, content1);
                      
                    }
                   
                        return RedirectToAction("ShowAllHD");
                  

                }
            }

            return BadRequest();


        }



        public async Task<IActionResult> Delete(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/HoaDonCT/HoaDonCT/delete/{id}";

            var response = await httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllHD");
            }
            ModelState.AddModelError("", "Delete sai R");
            return BadRequest();
        }





        public async Task<IActionResult> ShowAllHDCT(Guid idhd)
        {

            var httpClient = new HttpClient();

            var userIdinSession = HttpContext.Session.GetString("userId");


            if (!string.IsNullOrEmpty(userIdinSession))
            {
                Guid userId = Guid.Parse(userIdinSession);
                string apiURL3 = $"https://localhost:7001/api/User/User/{userId}";
             

                var response3 = await httpClient.GetAsync(apiURL3);
                string apiData3 = await response3.Content.ReadAsStringAsync();
                var result3 = JsonConvert.DeserializeObject<UserVM>(apiData3);
                ViewBag.UserData = new List<UserVM> { result3 };


                string apiURL = $"https://localhost:7001/api/HoaDonCT/HoaDonCT/{idhd}";

                var response = await httpClient.GetAsync(apiURL);

                string apiData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<HoaDonCTVM>(apiData);
                return View(result);

            }

            return RedirectToAction("DangNhap", "Acc");

        }











    }
}
