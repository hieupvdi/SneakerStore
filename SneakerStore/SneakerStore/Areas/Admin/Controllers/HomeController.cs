using AppData.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

//using static PRO219_WebsiteBanDienThoai_FPhone.Areas.Admin.Utilities.Utility;


namespace SneakerStore.Areas.Admin.Controllers  
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private HttpClient _client;
       
       
        
        public HomeController(HttpClient client)
        {
            _client = client;
         
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

       
    }
}