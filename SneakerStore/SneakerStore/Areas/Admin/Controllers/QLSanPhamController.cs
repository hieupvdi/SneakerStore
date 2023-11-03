using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace SneakerStore.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class QLSanPhamController : Controller
	{
		


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            string apiURL = "https://localhost:7001/api/CTSanPham/CTSanPham/get-all";
            var response = await httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<CTSanPhamVM>>(apiData);

            //ViewBag.CTSanPhamData = result;
        
            return View(result);
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CTSanPhamVM sp)
        {
            if (!ModelState.IsValid)
                return View(sp);

            var httpClient = new HttpClient();

            string apiURL = $"https://localhost:7001/api/CTSanPham/CTSanPham/create";

            var json = JsonConvert.SerializeObject(sp);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllSP");
            }
            ModelState.AddModelError("", "Sai roi");

            return View(sp);
        }




        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {

            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/ChucVu/ChucVu/{id}";

            var response = await httpClient.GetAsync(apiURL);

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<CTSanPhamVM>(apiData);
            return View(result);
        }

        public async Task<IActionResult> Edit(CTSanPhamVM nv)
        {

            if (!ModelState.IsValid) return View(nv);

            var httpClient = new HttpClient();
            string apiURL = $"";

            var json = JsonConvert.SerializeObject(nv);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            //var content = new StringContent(JsonConvert.SerializeObject(GiamGiaVM, Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }
            ModelState.AddModelError("", "sai roi be oi");

            return View(nv);
        }

        public async Task<IActionResult> Delete(Guid id)
        {


            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7133/api/NhanVien/Delete-Nhanvien?Id={id}";

            var response = await httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }
            ModelState.AddModelError("", "sai tiep roi be oi");
            return BadRequest();
        }











    }
}
