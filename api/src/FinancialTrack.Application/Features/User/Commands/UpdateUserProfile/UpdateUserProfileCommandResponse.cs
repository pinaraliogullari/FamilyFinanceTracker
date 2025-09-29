namespace FinancialTrack.Application.Features.User.Commands.UpdateUserProfile;

public class UpdateUserProfileCommandResponse
{
    public long Id { get; set; }
    public string FirstName { get; set; } 
    public string LastName { get; set; } 
    public string Email { get; set; }  
}