namespace FinancialTrack.Application.Features.User.Commands.CreateUser;

public class CreateUserCommandResponse
{
    public long Id { get; set; }
    public string Firstname { get; set; } 
    public string Lastname { get; set; } 
    public string Email { get; set; } 
}