using System.Net;

namespace FinancialTrack.Core.Results;

public interface IApiResult
{
    bool Success { get; set; }
    string Message { get; set; }
    HttpStatusCode StatusCode { get; set; }
}