using Microsoft.AspNetCore.Mvc;

namespace FinancialTrack.API.Controllers;

public class UserController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}