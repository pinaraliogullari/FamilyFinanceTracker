using FinancialTrack.Core.Markers;

namespace FinancialTrack.Application.Features.User.Commands.UpdateUserProfile;

public class UpdateUserProfileCommandRequest:IBaseCommandRequest<UpdateUserProfileCommandResponse>
{
    public long UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}