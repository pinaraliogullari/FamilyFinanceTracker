using System.Net;

namespace FinancialTrack.Core.Results;

public class ErrorResult<T> : ApiResult
{
    public T? Data { get; set; }

    public ErrorResult(T? data=default, string message = "Something went wrong",
        HttpStatusCode statusCode = HttpStatusCode.BadRequest) : base(false, message, statusCode)
    {
        Data = data;
    }
}