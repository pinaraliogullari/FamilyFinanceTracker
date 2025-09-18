using FinancialTrack.Application.Features.User.Queries.GetByIdUser;
using MediatR;

namespace FinancialTrack.Application.Features.FinancialRecord.Queries.GetByIdFinancialRecord;

public class GetByIdFinancialRecordQueryHandler:IRequestHandler<GetByIdFinancialRecordQueryRequest,GetByIdFinancialRecordQueryResponse>
{
    public Task<GetByIdFinancialRecordQueryResponse> Handle(GetByIdFinancialRecordQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}