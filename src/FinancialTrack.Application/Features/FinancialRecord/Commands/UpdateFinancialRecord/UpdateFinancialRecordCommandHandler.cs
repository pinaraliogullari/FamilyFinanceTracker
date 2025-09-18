using FinancialTrack.Application.Features.User.Commands.UpdateUser;
using MediatR;

namespace FinancialTrack.Application.Features.FinancialRecord.Commands.UpdateFinancialRecord;

public class UpdateFinancialRecordCommandHandler : IRequestHandler<UpdateFinancialRecordCommandRequest, UpdateFinancialRecordCommandResponse>
{
    public Task<UpdateFinancialRecordCommandResponse> Handle(UpdateFinancialRecordCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}