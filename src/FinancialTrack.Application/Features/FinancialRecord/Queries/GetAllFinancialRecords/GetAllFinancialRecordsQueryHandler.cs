using FinancialTrack.Application.Features.User.Queries.GetAllUsers;
using MediatR;

namespace FinancialTrack.Application.Features.FinancialRecord.Queries.GetAllFinancialRecords;

public class GetAllFinancialRecordsQueryHandler: IRequestHandler<GetAllFinancialRecordsQueryRequest, GetAllFinancialRecordsQueryResponse>
{
    public Task<GetAllFinancialRecordsQueryResponse> Handle(GetAllFinancialRecordsQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}