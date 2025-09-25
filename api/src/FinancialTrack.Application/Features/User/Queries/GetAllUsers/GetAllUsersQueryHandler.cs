using FinancialTrack.Application.Exceptions;
using FinancialTrack.Persistence.AbstractRepositories.UserRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FinancialTrack.Application.Features.User.Queries.GetAllUsers;

public class GetAllUsersQueryHandler: IRequestHandler<GetAllUsersQueryRequest, List<GetAllUsersQueryResponse>>
{
    private readonly IUserReadRepository _userReadRepository;


    public GetAllUsersQueryHandler(IUserReadRepository userReadRepository)
    {
        _userReadRepository = userReadRepository;
    }

    public async Task<List<GetAllUsersQueryResponse>> Handle(GetAllUsersQueryRequest request, CancellationToken cancellationToken)
    {
        var users = await _userReadRepository.GetAll(false)
            .Include(x => x.Role).ToListAsync();

        if (users == null || !users.Any())
            throw new NotFoundException("Any user not found");

        return users.Select(x => new GetAllUsersQueryResponse()
        {
            Id = x.Id,
            Firstname = x.FirstName,
            Lastname = x.LastName,
            Email = x.Email,
            RoleName = x.Role.Name,
        }).ToList();
    }
}