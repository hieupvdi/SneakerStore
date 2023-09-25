using AppData.Models;
using Microsoft.AspNetCore.Mvc;

namespace SneakerStore.Areas.Admin.Controllers;

[Area("Admin")]
public class LogInController : Controller
{
    private HttpClient _client;

    public LogInController(HttpClient client)
    {
        _client = client;
    }

    public async Task<IActionResult> Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(SignInModel model)
    {
        return View(model);
    }
}