using AppData.Models;
using AppData.SneakerDbContext;
using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http;
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
                ViewBag.UserId = userId;
                string apiURL = "https://localhost:7001/api/HoaDon/HoaDon/get-all";
          
                var response = await httpClient.GetAsync(apiURL);
                string apiData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<HoaDonVM>>(apiData);

                return View(result);

            }

            return RedirectToAction("DangNhap", "Acc");

        }



        #region TAOHD


        public async Task<IActionResult> ThanhToan(HoaDonVM hd)
        {
            if (hd.TongTien==0)
            {
                return RedirectToAction("ShowAllGHCT", "GioHang");


            }
            else
            {
                var httpClient = new HttpClient();

                var userIdinSession = HttpContext.Session.GetString("userId");


                if (!string.IsNullOrEmpty(userIdinSession))
                {
                    Guid userId = Guid.Parse(userIdinSession);

                    ViewBag.TongTienData = hd.TongTien;
                    ViewBag.DiaChiData = hd.DiaChi;
                    ViewBag.DiaChiData = hd.DiaChi;

                    if (hd.IdVoucher != null)
                    {
                        string apiURL = $"https://localhost:7001/api/Voucher/Voucher/{hd.IdVoucher}";
                        var response = await httpClient.GetAsync(apiURL);
                        string apiData = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<VoucherVM>(apiData);
                        ViewBag.VoucherData = new List<VoucherVM> { result };
                        decimal TongTienGiam = hd.TongTien - (hd.TongTien * result.PhanTram / 100);
                        ViewBag.TongTienGiamData = TongTienGiam;

                    }



                    string apiURL3 = $"https://localhost:7001/api/User/User/{userId}";
                    var response3 = await httpClient.GetAsync(apiURL3);
                    string apiData3 = await response3.Content.ReadAsStringAsync();
                    var result3 = JsonConvert.DeserializeObject<UserVM>(apiData3);
                    ViewBag.UserData = new List<UserVM> { result3 };


                    string apiURL6 = "https://localhost:7001/api/PhuongThucThanhToan/PTTT/get-all";
                    var response6 = await httpClient.GetAsync(apiURL6);
                    string apiData6 = await response6.Content.ReadAsStringAsync();
                    var result6 = JsonConvert.DeserializeObject<List<PhuongThucThanhToanVM>>(apiData6);
                    ViewBag.PTTTData = result6;

                    return View();

                }

                return RedirectToAction("DangNhap", "Acc");
            }




        }


        public async Task<IActionResult> CreateHD(HoaDonVM hoadon)
        {
            if (hoadon.NguoiNhan == null && hoadon.SDT==null)
            {
                return BadRequest("Đặt hàng không thành công thiếu người nhận hoặc sđt");

            }
            else
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
                //mã hd tự tăng=>

                string apiURL = "https://localhost:7001/api/HoaDon/HoaDon/get-all";
                var response = await httpClient.GetAsync(apiURL);
                string apiData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<HoaDonVM>>(apiData);

                var latestInvoice = result.OrderByDescending(h => h.MaHD).FirstOrDefault();
                int latestInvoiceNumber = latestInvoice != null ? int.Parse(latestInvoice.MaHD.Substring(3)) : 0;
                int newInvoiceNumber = latestInvoiceNumber + 1;
                string newMaHD = "HD:" + newInvoiceNumber.ToString();

                //<==mã tự tăng

                var hd = new HoaDonVM
                {
                    Id = Guid.NewGuid(),
                    IdUser = userId,
                    IdVoucher = hoadon.IdVoucher,
                    MaHD = newMaHD,
                    NgayTao = DateTime.Now,
                    NgayThanhToan = DateTime.Now,
                    NgayShip = DateTime.Now,
                    NgayNhan = DateTime.Now,
                    NguoiNhan = result3.HoTen,
                    PTThanhToan = hoadon.PTThanhToan,
                    DiaChi = hoadon.DiaChi,
                    SDT = result3.SDT,
                    TienShip = hoadon.TienShip,
                    TongTien = hoadon.TongTien,
                    TrangThai = 1,


                };

                var json = JsonConvert.SerializeObject(hd);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var Response = await httpClient.PostAsync(ApiURL, content);

                if (Response.IsSuccessStatusCode)//check hóa đơn tạo thành c
                {
                    //tạo Hóa đơn ct
                    string gioHangApiUrl = $"https://localhost:7001/api/GioHangCT/GioHangCT/{userIdinSession}";
                    var gioHangResponse = await httpClient.GetAsync(gioHangApiUrl);


                    string gioHangData = await gioHangResponse.Content.ReadAsStringAsync();
                    var gioHangDataList = JsonConvert.DeserializeObject<List<GioHangCTVM>>(gioHangData);


                    foreach (var gioHangCT in gioHangDataList)
                    {

                        var hdct = new HoaDonCTVM
                        {

                            IdHD = hd.Id,
                            IdCTSP = gioHangCT.IdCTSP,
                            SoLuong = gioHangCT.SoLuong,
                            DonGia = gioHangCT.DonGia,
                            TrangThai = 1,
                        };
                        //Thêm gh vào hóa đon
                        string hoaDonApiUrl = "https://localhost:7001/api/HoaDonCT/HoaDonCT/create";
                        var json1 = JsonConvert.SerializeObject(hdct);
                        var content1 = new StringContent(json1, Encoding.UTF8, "application/json");
                        var createHoaDonResponse = await httpClient.PostAsync(hoaDonApiUrl, content1);





                        // cập nhật số lượng

                        string CTSPApiURL = "https://localhost:7001/api/CTSanPham/CTSanPham/get-all";
                        var CTSPResponse = await httpClient.GetAsync(CTSPApiURL);
                        var CTSPResponseData = await CTSPResponse.Content.ReadAsStringAsync();
                        var lstCtspVM = JsonConvert.DeserializeObject<List<CTSanPhamVM>>(CTSPResponseData);

                        var ctsp = lstCtspVM.FirstOrDefault(x => x.Id == gioHangCT.IdCTSP);
                        ctsp.Id = gioHangCT.IdCTSP;
                        ctsp.SoLuongTon -= gioHangCT.SoLuong;


                        var updateProductdetailApiURL = $"https://localhost:7001/api/CTSanPham/CTSanPham/update/{gioHangCT.IdCTSP}";
                        var updateProductdetailJson = JsonConvert.SerializeObject(ctsp);
                        var updateProductdetailContent = new StringContent(updateProductdetailJson, Encoding.UTF8, "application/json");
                        var updateProductdetailResponse = await httpClient.PutAsync(updateProductdetailApiURL, updateProductdetailContent);

                        // xóa SP giỏ hàng
                        var deleteGHCTApiURL = $"https://localhost:7001/api/GioHangCT/GioHangCT/Delete/{gioHangCT.Id}";
                        var deleteGHCTReponse = await httpClient.DeleteAsync(deleteGHCTApiURL);

                    }

                    return RedirectToAction("ShowAllHD", new { id = hd.Id });





                }
                else
                {
                    return BadRequest("Tạo hóa đơn không thành công do: thiếu địa chỉ hoặc voucher");
                }
            }

        }



        public async Task<IActionResult> Delete(Guid idhd)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/HoaDon/HoaDon/Delete/{idhd}";
            var response = await httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                string HDapiURL = $"https://localhost:7001/api/HoaDonCT/HoaDonCT/GetHDCTUser/{idhd}";
                var HDresponse = await httpClient.GetAsync(HDapiURL);
                string HDapiData = await HDresponse.Content.ReadAsStringAsync();
                var HDresult = JsonConvert.DeserializeObject<List<HoaDonCTVM>>(HDapiData);



                // cập nhật số lượng

                string CTSPApiURL = "https://localhost:7001/api/CTSanPham/CTSanPham/get-all";
                var CTSPResponse = await httpClient.GetAsync(CTSPApiURL);
                var CTSPResponseData = await CTSPResponse.Content.ReadAsStringAsync();
                var lstCtspVM = JsonConvert.DeserializeObject<List<CTSanPhamVM>>(CTSPResponseData);
                foreach (var item in HDresult)
                {


                    var ctsp = lstCtspVM.FirstOrDefault(x => x.Id == item.IdCTSP);
                    ctsp.Id = item.IdCTSP;
                    ctsp.SoLuongTon += item.SoLuong;



                    var updateProductdetailApiURL = $"https://localhost:7001/api/CTSanPham/CTSanPham/update/{item.IdCTSP}";
                    var updateProductdetailJson = JsonConvert.SerializeObject(ctsp);
                    var updateProductdetailContent = new StringContent(updateProductdetailJson, Encoding.UTF8, "application/json");
                    var updateProductdetailResponse = await httpClient.PutAsync(updateProductdetailApiURL, updateProductdetailContent);
                }


                return RedirectToAction("ShowAllHD");
            }
            ModelState.AddModelError("", "Delete sai R");
            return BadRequest();
        }





        #endregion


        public async Task<IActionResult> ShowAllHDCT(Guid idhd)
        {

            var httpClient = new HttpClient();
            string apiURL1 = "https://localhost:7001/api/CTSanPham/CTSanPham/get-all";
            var response1 = await httpClient.GetAsync(apiURL1);
            string apiData1 = await response1.Content.ReadAsStringAsync();
            var result1 = JsonConvert.DeserializeObject<List<CTSanPhamVM>>(apiData1);
            ViewBag.CTSanPhamData = result1;
            string apiURL2 = "https://localhost:7001/api/AnhSanPham/AnhSanPham/get-all";
            var response2 = await httpClient.GetAsync(apiURL2);
            string apiData2 = await response2.Content.ReadAsStringAsync();
            var result2 = JsonConvert.DeserializeObject<List<AnhSanPhamVM>>(apiData2);
            ViewBag.AnhData = result2;


            string apiURL = $"https://localhost:7001/api/HoaDonCT/HoaDonCT/GetHDCTUser/{idhd}";

            var response = await httpClient.GetAsync(apiURL);

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<HoaDonCTVM>>(apiData);
            return View(result);



        }



    }
}
