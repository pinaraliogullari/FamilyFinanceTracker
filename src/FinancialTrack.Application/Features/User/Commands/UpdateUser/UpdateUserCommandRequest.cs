using MediatR;

namespace FinancialTrack.Application.Features.User.Commands.UpdateUser;

public class UpdateUserCommandRequest : IRequest<UpdateUserCommandResponse>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}