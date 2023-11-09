using Microsoft.AspNetCore.Mvc;

namespace SneakerStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DiaChiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
