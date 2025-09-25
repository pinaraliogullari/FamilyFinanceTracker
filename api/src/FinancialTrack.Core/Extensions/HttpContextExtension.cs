using Microsoft.AspNetCore.Http;

namespace FinancialTrack.Core.Extensions;

public static class HttpContextExtension
{
    public static string GetReferer(this HttpContext context)
        => context.Request.Headers["Referer"].ToString();

    public static string GetUserAgent(this HttpContext context)
        => context.Request.Headers["User-Agent"].ToString();

    public static string GetClientIpAddress(this HttpContext context)
        => context.Connection?.RemoteIpAddress?.ToString() ?? string.Empty;
}