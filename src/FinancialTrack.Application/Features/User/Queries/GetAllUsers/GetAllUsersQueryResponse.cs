using FinancialTrack.Application.DTOs;

namespace FinancialTrack.Application.Features.User.Queries.GetAllUsers;

public class GetAllUsersQueryResponse
{
    public List<UserDto> Users { get; set; }
}