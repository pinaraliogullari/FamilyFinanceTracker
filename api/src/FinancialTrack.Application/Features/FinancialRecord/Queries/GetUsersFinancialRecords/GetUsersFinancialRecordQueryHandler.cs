using FinancialTrack.Application.Exceptions;
using FinancialTrack.Core.UoW;
using FinancialTrack.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FinancialTrack.Application.Features.FinancialRecord.Queries.GetUsersFinancialRecords;

public class GetUsersFinancialRecordQueryHandler : IRequestHandler<GetUsersFinancialRecordQueryRequest,
    List<GetUsersFinancialRecordsQueryResponse>>
{
    private readonly IGenericUnitofWork<FinancialTrackDbContext> _uow;

    public GetUsersFinancialRecordQueryHandler(IGenericUnitofWork<FinancialTrackDbContext> uow)
    {
        _uow = uow;
    }

    public async Task<List<GetUsersFinancialRecordsQueryResponse>> Handle(GetUsersFinancialRecordQueryRequest request,
        CancellationToken cancellationToken)
    {
        var financialRecords = await _uow.GetReadRepository<Domain.Entities.FinancialRecord>()
            .GetWhere(x => x.UserId == request.UserId, false)
            .ToListAsync();
        if (!financialRecords.Any())
            throw new NotFoundException($"User with Id {request.UserId} has no financial records.");
        return financialRecords.Select(x => new GetUsersFinancialRecordsQueryResponse()
        {
            Amount = x.Amount,
            CategoryId = x.CategoryId,
            Description = x.Description,
            UserId = x.UserId,
            FinancialRecordId = x.Id
        }).ToList();
    }
}