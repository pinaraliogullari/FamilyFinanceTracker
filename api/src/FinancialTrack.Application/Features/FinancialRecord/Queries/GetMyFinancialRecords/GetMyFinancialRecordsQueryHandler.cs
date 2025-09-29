using FinancialTrack.Application.Exceptions;
using FinancialTrack.Core.AbstractServices;
using FinancialTrack.Core.UoW;
using FinancialTrack.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FinancialTrack.Application.Features.FinancialRecord.Queries.GetMyFinancialRecords;

public class GetMyFinancialRecordsQueryHandler : IRequestHandler<GetMyFinancialRecordsQueryRequest,
    List<GetMyFinancialRecordsQueryResponse>>
{
    private readonly IGenericUnitofWork<FinancialTrackDbContext> _uow;
    private readonly ICurrentUserService _currentUserService;

    public GetMyFinancialRecordsQueryHandler
    (
        IGenericUnitofWork<FinancialTrackDbContext> uow,
        ICurrentUserService currentUserService
    )
    {
        _uow = uow;
        _currentUserService = currentUserService;
    }


    public async Task<List<GetMyFinancialRecordsQueryResponse>> Handle(GetMyFinancialRecordsQueryRequest request,
        CancellationToken cancellationToken)
    {
        var userId = long.Parse(_currentUserService.UserId);
        var financialRecords =
            await _uow.GetReadRepository<Domain.Entities.FinancialRecord>()
                .GetWhere(x => x.UserId == userId, false)
                .Include(x => x.Category)
                .ToListAsync();
        if (financialRecords == null || !financialRecords.Any())
            throw new NotFoundException($"Financial Record not found for userId {userId}");
        return financialRecords.Select(x => new GetMyFinancialRecordsQueryResponse()
        {
            FinancialRecordId = x.Id,
            Amount = x.Amount,
            CategoryId = x.CategoryId,
            Description = x.Description,
            CategoryName = x.Category.Name,
            FinancialRecordType = x.FinancialRecordType.ToString()
        }).ToList();
    }
}