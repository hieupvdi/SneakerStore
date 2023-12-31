﻿using AppData.Models;
using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace SneakerStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HoaDonController : Controller
    {
        public HoaDonController()
        {
            
        }
        public async Task<IActionResult> ShowAllHD()
        {
            var httpClient = new HttpClient();
            string apiURL = "https://localhost:7001/api/HoaDon/HoaDon/get-all";
            var response = await httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<HoaDonVM>>(apiData);
            return View(result);
        }
        public async Task<IActionResult> XacNhan(Guid idhd)
        {
            var httpClient = new HttpClient();

            string apiURL3 = $"https://localhost:7001/api/HoaDon/HoaDon/{idhd}";
            var response3 = await httpClient.GetAsync(apiURL3);
            string apiData3 = await response3.Content.ReadAsStringAsync();
            var result3 = JsonConvert.DeserializeObject<HoaDonVM>(apiData3);


            result3.TrangThai = 2;
            var updateHDApiURL = $"https://localhost:7001/api/HoaDon/HoaDon/update/{idhd}";
            var updateHDJson = JsonConvert.SerializeObject(result3);
            var updateHDContent = new StringContent(updateHDJson, Encoding.UTF8, "application/json");
            var updateHDResponse = await httpClient.PutAsync(updateHDApiURL, updateHDContent);

            if (updateHDResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllHD", "HoaDon");
            }
            ModelState.AddModelError("", "Xác Nhận Đơn không thành công");
            return View();
           
        }






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
