using System.Net;
using FinancialTrack.Core.Results;
using Microsoft.AspNetCore.Mvc;

namespace FinancialTrack.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{
    protected IApiResult HandleApiResponse<T>(T? result = default, string successMessage = "Operation successful",
        HttpStatusCode httpStatusCode = HttpStatusCode.OK)
    {
        return new SuccessResult<T>(result, successMessage, httpStatusCode);
    }
}