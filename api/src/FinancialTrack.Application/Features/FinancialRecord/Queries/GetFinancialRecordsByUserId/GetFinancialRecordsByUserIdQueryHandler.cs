using FinancialTrack.Application.Exceptions;
using FinancialTrack.Core.UoW;
using FinancialTrack.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FinancialTrack.Application.Features.FinancialRecord.Queries.GetFinancialRecordsByUserId;

public class GetFinancialRecordsByUserIdQueryHandler : IRequestHandler<GetFinancialRecordsByUserIdQueryRequest,
    List<GetFinancialRecordsByUserIdQueryResponse>>
{
    private readonly IGenericUnitofWork<FinancialTrackDbContext> _uow;

    public GetFinancialRecordsByUserIdQueryHandler(IGenericUnitofWork<FinancialTrackDbContext> uow)
    {
        _uow = uow;
    }

    public async Task<List<GetFinancialRecordsByUserIdQueryResponse>> Handle(GetFinancialRecordsByUserIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        var financialRecords = await _uow.GetReadRepository<Domain.Entities.FinancialRecord>()
            .GetWhere(x => x.UserId == request.UserId, false)
            .ToListAsync();
        if (!financialRecords.Any())
            throw new NotFoundException($"User with Id {request.UserId} has no financial records.");
        return financialRecords.Select(x => new GetFinancialRecordsByUserIdQueryResponse()
        {
            Amount = x.Amount,
            CategoryId = x.CategoryId,
            Description = x.Description,
            UserId = x.UserId,
            FinancialRecordId = x.Id
        }).ToList();
    }
}