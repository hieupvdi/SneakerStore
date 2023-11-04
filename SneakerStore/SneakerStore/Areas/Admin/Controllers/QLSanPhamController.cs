using AppData.Models;
using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace SneakerStore.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class QLSanPhamController : Controller
	{

        public QLSanPhamController()
        {
            
        }

        public async Task<IActionResult> ShowAllQLSP()
        {
            var httpClient = new HttpClient();
            string apiURL = "https://localhost:7001/api/CTSanPham/CTSanPham/get-all";
            var response = await httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<CTSanPhamVM>>(apiData);
            return View(result);
        }


        public async Task<IActionResult> Create()
        {
            var httpClient = new HttpClient();

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
            var response4 = await httpClient.GetAsync(apiURL3);
            string apiData4 = await response4.Content.ReadAsStringAsync();
            // Lấy kết quả thu được bằng cách bóc dữ liệu Json
            var result4 = JsonConvert.DeserializeObject<List<AnhSanPhamVM>>(apiData4);


            string apiURL5 = "https://localhost:7001/api/SanPham/SanPham/get-all";
            var response5 = await httpClient.GetAsync(apiURL5);
            string apiData5 = await response5.Content.ReadAsStringAsync();
            // Lấy kết quả thu được bằng cách bóc dữ liệu Json
            var result5 = JsonConvert.DeserializeObject<List<SanPhamVM>>(apiData5);


            ViewBag.MauSacData = result1;
            ViewBag.SizeData = result2;
            ViewBag.DanhMucData = result3;
            ViewBag.AnhData = result4;
            ViewBag.SanPhamData = result5;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CTSanPhamVM ctsp)
        {
            //if (!ModelState.IsValid)
            //    return View(CTSanPham);

            var httpClient = new HttpClient();

            string apiURL = "https://localhost:7001/api/CTSanPham/CTSanPham/create";

            var json = JsonConvert.SerializeObject(ctsp);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllQLSP");
            }
            ModelState.AddModelError("", "Create Sai roi");


            return View(ctsp);

        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/CTSanPham/CTSanPham/{id}";

            var response = await httpClient.GetAsync(apiURL);

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<CTSanPhamVM>(apiData);
            return View(result);
        }

        public async Task<IActionResult> Edit(CTSanPhamVM ctsp)
        {
            if (!ModelState.IsValid) return View(ctsp);

            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/CTSanPham/CTSanPham/update/{ctsp.Id}";

            var json = JsonConvert.SerializeObject(ctsp);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllQLSP");
            }
            ModelState.AddModelError("", "Edit sai r");

            return View(ctsp);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/CTSanPham/CTSanPham/delete/{id}";

            var response = await httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllQLSP");
            }
            ModelState.AddModelError("", "Delete sai R");
            return BadRequest();
        }










    }
}
