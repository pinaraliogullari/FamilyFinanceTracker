using FinancialTrack.Application.Exceptions;
using FinancialTrack.Persistence.AbstractRepositories.FinancialRecordRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FinancialTrack.Application.Features.FinancialRecord.Queries.GetAllFinancialRecords;

public class
    GetAllFinancialRecordsQueryHandler : IRequestHandler<GetAllFinancialRecordsQueryRequest,
    List<GetAllFinancialRecordsQueryResponse>>
{
    private readonly IFinancialRecordReadRepository _financialRecordReadRepository;

    public GetAllFinancialRecordsQueryHandler(IFinancialRecordReadRepository financialRecordReadRepository)
    {
        _financialRecordReadRepository = financialRecordReadRepository;
    }

    public async Task<List<GetAllFinancialRecordsQueryResponse>> Handle(GetAllFinancialRecordsQueryRequest request,
        CancellationToken cancellationToken)
    {
        var financialRecords = await _financialRecordReadRepository.GetAll(false).ToListAsync();
        if (financialRecords == null || !financialRecords.Any())
            throw new NotFoundException("Financial Record Not Found");
        return financialRecords.Select(x => new GetAllFinancialRecordsQueryResponse()
        {
            FinancialRecordId = x.Id,
            Amount = x.Amount,
            CategoryId = x.CategoryId,
            Description = x.Description,
            UserId = x.UserId
        }).ToList();
    }
}