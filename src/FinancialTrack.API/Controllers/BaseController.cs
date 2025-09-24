using Microsoft.AspNetCore.Mvc;

namespace FinancialTrack.API.Controllers;

[ApiController]
public class BaseController : ControllerBase
{
    // GET
    public IActionResult Index()
    {
        return Ok();
    }
}