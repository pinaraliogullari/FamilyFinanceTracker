using FinancialTrack.Application.Exceptions;
using FinancialTrack.Core.UoW;
using FinancialTrack.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FinancialTrack.Application.Features.FinancialRecord.Queries.GetAllFinancialRecords;

public class
    GetAllFinancialRecordsQueryHandler : IRequestHandler<GetAllFinancialRecordsQueryRequest,
    List<GetAllFinancialRecordsQueryResponse>>
{
    private readonly IGenericUnitofWork<FinancialTrackDbContext> _uow;

    public GetAllFinancialRecordsQueryHandler(IGenericUnitofWork<FinancialTrackDbContext> uow)
    {
        _uow = uow;
    }

    public async Task<List<GetAllFinancialRecordsQueryResponse>> Handle(GetAllFinancialRecordsQueryRequest request,
        CancellationToken cancellationToken)
    {
        var financialRecords =
            await _uow.GetReadRepository<Domain.Entities.FinancialRecord>()
                .GetAll()
                .Include(x=>x.User)
                .Include(x=>x.Category)
               .ToListAsync();
        if (financialRecords == null || !financialRecords.Any())
            throw new NotFoundException("Financial Record Not Found");
        return financialRecords.Select(x => new GetAllFinancialRecordsQueryResponse()
        {
            FinancialRecordId = x.Id,
            Amount = x.Amount,
            CategoryId = x.CategoryId,
            Description = x.Description,
            UserId = x.UserId,
            UserFirstName = x.User.FirstName,
            UserLastName = x.User.LastName,
            CategoryName = x.Category.Name,
            FinancialRecordType = x.FinancialRecordType.ToString()
            
        }).ToList();
    }
}