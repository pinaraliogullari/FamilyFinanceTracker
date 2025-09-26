using System.Net;

namespace FinancialTrack.Core.Results;

public class ApiResult : IApiResult
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public HttpStatusCode StatusCode { get; set; }

    public ApiResult(bool success, string message, HttpStatusCode statusCode)
    {
        Success = success;
        Message = message;
        StatusCode = statusCode;
    }
}