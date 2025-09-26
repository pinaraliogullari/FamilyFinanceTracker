using System.Net;

namespace FinancialTrack.Core.Results;

public class SuccessResult<T> : ApiResult
{
    public T? Data { get; set; }

    public SuccessResult(T? data, string message = "Operation successfull",
        HttpStatusCode statusCode = HttpStatusCode.OK) : base(true, message, statusCode)
    {
        Data = data;
    }
}