using System.Net;
using FinancialTrack.Application.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace FinancialTrack.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{
    protected IActionResult HandleApiResponse<T>(T? result, string successMessage = "Operation successful",
        HttpStatusCode httpStatusCode = HttpStatusCode.OK)
    {
        //data-success
        if (result is not null)
        {
            return StatusCode((int)httpStatusCode, ApiResult<T>.SuccessResult(result, successMessage, httpStatusCode));
        }

        //no data-success
        return StatusCode((int)httpStatusCode, ApiResult<T>.SuccessResult(successMessage, httpStatusCode));
    }
}