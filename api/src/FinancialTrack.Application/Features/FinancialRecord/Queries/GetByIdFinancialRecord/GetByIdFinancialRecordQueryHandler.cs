using FinancialTrack.Application.Exceptions;
using FinancialTrack.Application.Features.User.Queries.GetByIdUser;
using FinancialTrack.Persistence.AbstractRepositories.FinancialRecordRepository;
using MediatR;

namespace FinancialTrack.Application.Features.FinancialRecord.Queries.GetByIdFinancialRecord;

public class
    GetByIdFinancialRecordQueryHandler : IRequestHandler<GetByIdFinancialRecordQueryRequest,
    GetByIdFinancialRecordQueryResponse>
{
    private readonly IFinancialRecordReadRepository _financialRecordReadRepository;

    public GetByIdFinancialRecordQueryHandler(IFinancialRecordReadRepository financialRecordReadRepository)
    {
        _financialRecordReadRepository = financialRecordReadRepository;
    }

    public async Task<GetByIdFinancialRecordQueryResponse> Handle(GetByIdFinancialRecordQueryRequest request,
        CancellationToken cancellationToken)
    {
        var financialRecord = await _financialRecordReadRepository.GetByIdAsync(request.FinancialRecordId, false);
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