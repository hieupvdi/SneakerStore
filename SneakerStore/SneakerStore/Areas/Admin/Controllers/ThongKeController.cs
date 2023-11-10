using Microsoft.AspNetCore.Mvc;

namespace SneakerStore.Areas.Admin.Controllers
{
    public class ThongKeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
