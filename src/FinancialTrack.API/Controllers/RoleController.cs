using Microsoft.AspNetCore.Mvc;

namespace FinancialTrack.API.Controllers;

public class RoleController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}