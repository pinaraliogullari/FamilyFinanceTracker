using Microsoft.AspNetCore.Mvc;

namespace FinancialTrack.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FinancialRecordController : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return Ok();
    }
}