using AppData.Models;
using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text;

namespace SneakerStore.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class QLSanPhamController : Controller
	{

        public QLSanPhamController()
        {
            
        }
        #region CTSP
        public async Task<IActionResult> ShowAllQLSP()
        {
            var httpClient = new HttpClient();
            string apiURL = "https://localhost:7001/api/CTSanPham/CTSanPham/get-all";
            var response = await httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<CTSanPhamVM>>(apiData);

            string apiURL4 = "https://localhost:7001/api/AnhSanPham/AnhSanPham/get-all";
            var response4 = await httpClient.GetAsync(apiURL4);
            string apiData4 = await response4.Content.ReadAsStringAsync();
            var result4 = JsonConvert.DeserializeObject<List<AnhSanPhamVM>>(apiData4);

            ViewBag.AnhData = result4;

            return View(result);
        }


        public async Task<IActionResult> Create()
        {
            var httpClient = new HttpClient();

            string apiURL1 = "https://localhost:7001/api/MauSac/MauSac/get-all";
            var response1 = await httpClient.GetAsync(apiURL1);
            string apiData1 = await response1.Content.ReadAsStringAsync();
            var result1 = JsonConvert.DeserializeObject<List<MauSacVM>>(apiData1);

            string apiURL2 = "https://localhost:7001/api/Size/Size/get-all";
            var response2 = await httpClient.GetAsync(apiURL2);
            string apiData2 = await response2.Content.ReadAsStringAsync();
            var result2 = JsonConvert.DeserializeObject<List<SizeVM>>(apiData2);

            string apiURL3 = "https://localhost:7001/api/DanhMuc/DanhMuc/get-all";
            var response3 = await httpClient.GetAsync(apiURL3);
            string apiData3 = await response3.Content.ReadAsStringAsync();
            var result3 = JsonConvert.DeserializeObject<List<DanhMucVM>>(apiData3);

            string apiURL4 = "https://localhost:7001/api/AnhSanPham/AnhSanPham/get-all";
            var response4 = await httpClient.GetAsync(apiURL4);
            string apiData4 = await response4.Content.ReadAsStringAsync();
            var result4 = JsonConvert.DeserializeObject<List<AnhSanPhamVM>>(apiData4);

            string apiURL5 = "https://localhost:7001/api/SanPham/SanPham/get-all";
            var response5 = await httpClient.GetAsync(apiURL5);
            string apiData5 = await response5.Content.ReadAsStringAsync();
            var result5 = JsonConvert.DeserializeObject<List<SanPhamVM>>(apiData5);

            string apiURL6 = "https://localhost:7001/api/GiamGia/GiamGia/get-all";
            var response6 = await httpClient.GetAsync(apiURL6);
            string apiData6 = await response6.Content.ReadAsStringAsync();
            var result6 = JsonConvert.DeserializeObject<List<GiamGiaVM>>(apiData6);

            string apiURL7 = "https://localhost:7001/api/DeGiay/DeGiay/get-all";
            var response7 = await httpClient.GetAsync(apiURL7);
            string apiData7 = await response7.Content.ReadAsStringAsync();
            var result7 = JsonConvert.DeserializeObject<List<DeGiayVM>>(apiData7);

            ViewBag.MauSacData = result1;
            ViewBag.SizeData = result2;
            ViewBag.DanhMucData = result3;
            ViewBag.AnhData = result4;
            ViewBag.SanPhamData = result5;
            ViewBag.GiamGiaData = result6;
            ViewBag.DeGiayData = result7;

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CTSanPhamVM ctsp)
        {
        

            var httpClient = new HttpClient();

            #region LOAD Dropdowns

            string apiURL1 = "https://localhost:7001/api/MauSac/MauSac/get-all";
            var response1 = await httpClient.GetAsync(apiURL1);
            string apiData1 = await response1.Content.ReadAsStringAsync();
            var result1 = JsonConvert.DeserializeObject<List<MauSacVM>>(apiData1);

            string apiURL2 = "https://localhost:7001/api/Size/Size/get-all";
            var response2 = await httpClient.GetAsync(apiURL2);
            string apiData2 = await response2.Content.ReadAsStringAsync();
            var result2 = JsonConvert.DeserializeObject<List<SizeVM>>(apiData2);

            string apiURL3 = "https://localhost:7001/api/DanhMuc/DanhMuc/get-all";
            var response3 = await httpClient.GetAsync(apiURL3);
            string apiData3 = await response3.Content.ReadAsStringAsync();
            var result3 = JsonConvert.DeserializeObject<List<DanhMucVM>>(apiData3);

            string apiURL4 = "https://localhost:7001/api/AnhSanPham/AnhSanPham/get-all";
            var response4 = await httpClient.GetAsync(apiURL4);
            string apiData4 = await response4.Content.ReadAsStringAsync();
            var result4 = JsonConvert.DeserializeObject<List<AnhSanPhamVM>>(apiData4);

            string apiURL5 = "https://localhost:7001/api/SanPham/SanPham/get-all";
            var response5 = await httpClient.GetAsync(apiURL5);
            string apiData5 = await response5.Content.ReadAsStringAsync();
            var result5 = JsonConvert.DeserializeObject<List<SanPhamVM>>(apiData5);

            string apiURL6 = "https://localhost:7001/api/GiamGia/GiamGia/get-all";
            var response6 = await httpClient.GetAsync(apiURL6);
            string apiData6 = await response6.Content.ReadAsStringAsync();
            var result6 = JsonConvert.DeserializeObject<List<GiamGiaVM>>(apiData6);

            string apiURL7 = "https://localhost:7001/api/DeGiay/DeGiay/get-all";
            var response7 = await httpClient.GetAsync(apiURL7);
            string apiData7 = await response7.Content.ReadAsStringAsync();
            var result7 = JsonConvert.DeserializeObject<List<DeGiayVM>>(apiData7);

            ViewBag.MauSacData = result1;
            ViewBag.SizeData = result2;
            ViewBag.DanhMucData = result3;
            ViewBag.AnhData = result4;
            ViewBag.SanPhamData = result5;
            ViewBag.GiamGiaData = result6;
            ViewBag.DeGiayData = result7;

            #endregion

            if (!ModelState.IsValid)
                return View(ctsp);

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
            string apiURL1 = "https://localhost:7001/api/MauSac/MauSac/get-all";
            var response1 = await httpClient.GetAsync(apiURL1);
            string apiData1 = await response1.Content.ReadAsStringAsync();
            var result1 = JsonConvert.DeserializeObject<List<MauSacVM>>(apiData1);

            string apiURL2 = "https://localhost:7001/api/Size/Size/get-all";
            var response2 = await httpClient.GetAsync(apiURL2);
            string apiData2 = await response2.Content.ReadAsStringAsync();
            var result2 = JsonConvert.DeserializeObject<List<SizeVM>>(apiData2);

            string apiURL3 = "https://localhost:7001/api/DanhMuc/DanhMuc/get-all";
            var response3 = await httpClient.GetAsync(apiURL3);
            string apiData3 = await response3.Content.ReadAsStringAsync();
            var result3 = JsonConvert.DeserializeObject<List<DanhMucVM>>(apiData3);

            string apiURL4 = "https://localhost:7001/api/AnhSanPham/AnhSanPham/get-all";
            var response4 = await httpClient.GetAsync(apiURL4);
            string apiData4 = await response4.Content.ReadAsStringAsync();
            var result4 = JsonConvert.DeserializeObject<List<AnhSanPhamVM>>(apiData4);

            string apiURL5 = "https://localhost:7001/api/SanPham/SanPham/get-all";
            var response5 = await httpClient.GetAsync(apiURL5);
            string apiData5 = await response5.Content.ReadAsStringAsync();
            var result5 = JsonConvert.DeserializeObject<List<SanPhamVM>>(apiData5);

            string apiURL6 = "https://localhost:7001/api/GiamGia/GiamGia/get-all";
            var response6 = await httpClient.GetAsync(apiURL6);
            string apiData6 = await response6.Content.ReadAsStringAsync();
            var result6 = JsonConvert.DeserializeObject<List<GiamGiaVM>>(apiData6);

            string apiURL7 = "https://localhost:7001/api/DeGiay/DeGiay/get-all";
            var response7 = await httpClient.GetAsync(apiURL7);
            string apiData7 = await response7.Content.ReadAsStringAsync();
            var result7 = JsonConvert.DeserializeObject<List<DeGiayVM>>(apiData7);

            ViewBag.MauSacData = result1;
            ViewBag.SizeData = result2;
            ViewBag.DanhMucData = result3;
            ViewBag.AnhData = result4;
            ViewBag.SanPhamData = result5;
            ViewBag.GiamGiaData = result6;
            ViewBag.DeGiayData = result7;




           
            string apiURL = $"https://localhost:7001/api/CTSanPham/CTSanPham/{id}";

            var response = await httpClient.GetAsync(apiURL);

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<CTSanPhamVM>(apiData);
            return View(result);
        }

        public async Task<IActionResult> Edit(CTSanPhamVM ctsp)
        {
      
            var httpClient = new HttpClient();

            #region LOAD Dropdowns

            string apiURL1 = "https://localhost:7001/api/MauSac/MauSac/get-all";
            var response1 = await httpClient.GetAsync(apiURL1);
            string apiData1 = await response1.Content.ReadAsStringAsync();
            var result1 = JsonConvert.DeserializeObject<List<MauSacVM>>(apiData1);

            string apiURL2 = "https://localhost:7001/api/Size/Size/get-all";
            var response2 = await httpClient.GetAsync(apiURL2);
            string apiData2 = await response2.Content.ReadAsStringAsync();
            var result2 = JsonConvert.DeserializeObject<List<SizeVM>>(apiData2);

            string apiURL3 = "https://localhost:7001/api/DanhMuc/DanhMuc/get-all";
            var response3 = await httpClient.GetAsync(apiURL3);
            string apiData3 = await response3.Content.ReadAsStringAsync();
            var result3 = JsonConvert.DeserializeObject<List<DanhMucVM>>(apiData3);

            string apiURL4 = "https://localhost:7001/api/AnhSanPham/AnhSanPham/get-all";
            var response4 = await httpClient.GetAsync(apiURL4);
            string apiData4 = await response4.Content.ReadAsStringAsync();
            var result4 = JsonConvert.DeserializeObject<List<AnhSanPhamVM>>(apiData4);

            string apiURL5 = "https://localhost:7001/api/SanPham/SanPham/get-all";
            var response5 = await httpClient.GetAsync(apiURL5);
            string apiData5 = await response5.Content.ReadAsStringAsync();
            var result5 = JsonConvert.DeserializeObject<List<SanPhamVM>>(apiData5);

            string apiURL6 = "https://localhost:7001/api/GiamGia/GiamGia/get-all";
            var response6 = await httpClient.GetAsync(apiURL6);
            string apiData6 = await response6.Content.ReadAsStringAsync();
            var result6 = JsonConvert.DeserializeObject<List<GiamGiaVM>>(apiData6);

            string apiURL7 = "https://localhost:7001/api/DeGiay/DeGiay/get-all";
            var response7 = await httpClient.GetAsync(apiURL7);
            string apiData7 = await response7.Content.ReadAsStringAsync();
            var result7 = JsonConvert.DeserializeObject<List<DeGiayVM>>(apiData7);

            ViewBag.MauSacData = result1;
            ViewBag.SizeData = result2;
            ViewBag.DanhMucData = result3;
            ViewBag.AnhData = result4;
            ViewBag.SanPhamData = result5;
            ViewBag.GiamGiaData = result6;
            ViewBag.DeGiayData = result7;

            #endregion

            if (!ModelState.IsValid)
                return View(ctsp);

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



        #endregion





    }
}
