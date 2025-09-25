using FinancialTrack.Application.Exceptions;
using FinancialTrack.Core.UoW;
using FinancialTrack.Persistence.Context;
using MediatR;

namespace FinancialTrack.Application.Features.FinancialRecord.Queries.GetByIdFinancialRecord;

public class
    GetByIdFinancialRecordQueryHandler : IRequestHandler<GetByIdFinancialRecordQueryRequest,
    GetByIdFinancialRecordQueryResponse>
{
    private readonly IGenericUnitofWork<FinancialTrackDbContext> _uow;

    public GetByIdFinancialRecordQueryHandler(IGenericUnitofWork<FinancialTrackDbContext> uow)
    {
        _uow = uow;
    }

    public async Task<GetByIdFinancialRecordQueryResponse> Handle(GetByIdFinancialRecordQueryRequest request,
        CancellationToken cancellationToken)
    {
        var financialRecord = await _uow.GetReadRepository<Domain.Entities.FinancialRecord>()
            .GetByIdAsync(request.FinancialRecordId, false);
        if (financialRecord == null)
            throw new NotFoundException($"FinancialRecord with id {request.FinancialRecordId} not found");
        return new GetByIdFinancialRecordQueryResponse()
        {
            FinancialRecordId = financialRecord.Id,
            Amount = financialRecord.Amount,
            CategoryId = financialRecord.CategoryId,
            Description = financialRecord.Description,
            UserId = financialRecord.UserId,
        };
    }
}