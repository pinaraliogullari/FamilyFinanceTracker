namespace FinancialTrack.Infrastructure.AbstractServices;

public interface ICurrentUserService
{
   string? Token { get; }
   string UserId { get; }
   string Email { get; }
   string Role { get; }
   string Referer { get; }// istek hangi sayfadan geldi
   string UserAgent { get; }//istek hangi tarayıcıdan, cihazdan geldi
   string IPAddress { get; }
}