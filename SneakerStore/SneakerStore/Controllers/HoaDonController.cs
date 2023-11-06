using Microsoft.AspNetCore.Mvc;

namespace SneakerStore.Controllers
{
	public class HoaDonController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
