using Microsoft.AspNetCore.Mvc;

namespace FinancialTrack.API.Controllers;

public class FinancialRecordController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}