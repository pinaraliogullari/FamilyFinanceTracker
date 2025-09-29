using FinancialTrack.Application.Exceptions;
using FinancialTrack.Core.UoW;
using FinancialTrack.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FinancialTrack.Application.Features.FinancialRecord.Queries.GetFinancialRecordsByType;

public class GetFinancialRecordsByTypeQueryHandler : IRequestHandler<GetFinancialRecordsByTypeQueryRequest,
    List<GetFinancialRecordsByTypeQueryResponse>>
{
    private readonly IGenericUnitofWork<FinancialTrackDbContext> _uow;

    public GetFinancialRecordsByTypeQueryHandler(IGenericUnitofWork<FinancialTrackDbContext> uow)
    {
        _uow = uow;
    }


    public async Task<List<GetFinancialRecordsByTypeQueryResponse>> Handle(
        GetFinancialRecordsByTypeQueryRequest request, CancellationToken cancellationToken)
    {
        var query = _uow.GetReadRepository<Domain.Entities.FinancialRecord>()
            .GetAll()
            .Include(x => x.User)
            .Include(x => x.Category).AsQueryable();

        query = query.Where(x => x.Category.FinancialRecordType == request.FinancialRecordType);
        var financialRecords = await query.ToListAsync();
        
        if (!financialRecords.Any())
            throw new NotFoundException("Financial Record Not Found");
        
        return financialRecords.Select(x=> new GetFinancialRecordsByTypeQueryResponse()
        {
            FinancialRecordId = x.Id,
            Amount = x.Amount,
            CategoryId = x.CategoryId,
            Description = x.Description,
            UserId = x.UserId,
            UserFirstName = x.User.FirstName,
            UserLastName = x.User.LastName,
            CategoryName = x.Category.Name,
            FinancialRecordType = x.Category.FinancialRecordType.ToString()
        }).ToList();
    }
}