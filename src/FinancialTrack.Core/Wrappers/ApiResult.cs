using System.Net;

namespace FinancialTrack.Application.Wrappers;

public class ApiResult<T>
{
    public T? Data { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public List<string> Errors { get; set; }

    public ApiResult(T? data, bool success, string message, HttpStatusCode statusCode, List<string> errors)
    {
        Data = data;
        Success = success;
        Message = message;
        StatusCode = statusCode;
        Errors = errors ?? new List<string>();
    }


    //data ile success result
    public static ApiResult<T> SuccessResult(T data, string message = "Operation successful.",
        HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        return new ApiResult<T>(data, true, message, statusCode, null);
    }

    //datasız success result
    public static ApiResult<T> SuccessResult(string message = "Operation successful.",
        HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        return new ApiResult<T>(default, true, message, statusCode, null);
    }

    //hata result 
    public static ApiResult<T> FailureResult(string message = "Operation failed.",
        HttpStatusCode statusCode = HttpStatusCode.BadRequest,List<string>? errors = null)
    {
        return new ApiResult<T>(default, false, message, statusCode, errors);
    }
}