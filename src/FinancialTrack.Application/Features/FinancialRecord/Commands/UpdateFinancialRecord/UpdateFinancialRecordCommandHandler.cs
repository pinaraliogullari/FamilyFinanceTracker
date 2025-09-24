using FinancialTrack.Application.Features.User.Commands.UpdateUser;
using FinancialTrack.Application.Wrappers;
using MediatR;

namespace FinancialTrack.Application.Features.FinancialRecord.Commands.UpdateFinancialRecord;

public class UpdateFinancialRecordCommandHandler : IRequestHandler<UpdateFinancialRecordCommandRequest, ApiResult<UpdateFinancialRecordCommandResponse>>
{
    public Task<ApiResult<UpdateFinancialRecordCommandResponse>> Handle(UpdateFinancialRecordCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}