namespace FinancialTrack.Application.Features.User.Commands.UpdateUserPassword;

public class UpdateUserPasswordCommandResponse
{
    public long UserId { get; set; }
    public bool IsSuccess { get; set; }
    public string Message { get; set; } 
}