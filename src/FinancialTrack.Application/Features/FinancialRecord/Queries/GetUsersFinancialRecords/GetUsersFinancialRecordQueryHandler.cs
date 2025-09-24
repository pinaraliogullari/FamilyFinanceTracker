using MediatR;

namespace FinancialTrack.Application.Features.FinancialRecord.Queries.GetUsersFinancialRecords;

public class GetUsersFinancialRecordQueryHandler:IRequestHandler<GetUsersFinancialRecordQueryRequest,GetUsersFinancialRecordsQueryResponse>
{
    public Task<GetUsersFinancialRecordsQueryResponse> Handle(GetUsersFinancialRecordQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}