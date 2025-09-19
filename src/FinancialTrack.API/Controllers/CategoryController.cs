using Microsoft.AspNetCore.Mvc;

namespace FinancialTrack.API.Controllers;

public class CategoryController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}