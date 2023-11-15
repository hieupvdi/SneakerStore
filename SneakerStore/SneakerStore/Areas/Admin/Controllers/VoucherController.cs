using AppData.Models;
using AppData.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace SneakerStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VoucherController : Controller
    {
        public VoucherController()
        {
            
        }
        public async Task<IActionResult> ShowAllVoucher()
        {
            var httpClient = new HttpClient();
            string apiURL = "https://localhost:7001/api/Voucher/Voucher/get-all";
            var response = await httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<VoucherVM>>(apiData);
            return View(result);
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(VoucherVM vo)
        {
            if (!ModelState.IsValid)
                return View(vo);

            var httpClient = new HttpClient();

            string apiURL = "https://localhost:7001/api/Voucher/Voucher/create";

            var json = JsonConvert.SerializeObject(vo);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllVoucher");
            }
            ModelState.AddModelError("", "Create Sai roi");

            return View(vo);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/Voucher/Voucher/{id}";

            var response = await httpClient.GetAsync(apiURL);

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<VoucherVM>(apiData);
            return View(result);
        }

        public async Task<IActionResult> Edit(VoucherVM vo)
        {
            if (!ModelState.IsValid) 
                return View(vo);

            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/Voucher/Voucher/update/{vo.Id}";

            var json = JsonConvert.SerializeObject(vo);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllVoucher");
            }
            ModelState.AddModelError("", "Edit sai r");

            return View(vo);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7001/api/Voucher/Voucher/delete/{id}";

            var response = await httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllVoucher");
            }
            ModelState.AddModelError("", "Delete sai R");
            return BadRequest();
        }
    }
}
