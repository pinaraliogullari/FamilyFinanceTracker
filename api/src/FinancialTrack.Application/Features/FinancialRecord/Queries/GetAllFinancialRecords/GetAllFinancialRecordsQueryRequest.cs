using FinancialTrack.Application.Features.User.Queries.GetAllUsers;
using FinancialTrack.Application.Markers;
using FinancialTrack.Core.Markers;
using MediatR;

namespace FinancialTrack.Application.Features.FinancialRecord.Queries.GetAllFinancialRecords;

public class GetAllFinancialRecordsQueryRequest: IBaseQueryRequest<List<GetAllFinancialRecordsQueryResponse>>
{
   
}