using FinancialTrack.Application.Features.FinancialRecord.Commands.DeleteFinancialRecord;
using MediatR;

namespace FinancialTrack.Application.Features.User.Commands.DeleteUser;

public class DeleteFinancialRecordCommandHandler : IRequestHandler<DeleteFinancialRecordCommandRequest,
    DeleteFinancialRecordCommandResponse>
{
    public Task<DeleteFinancialRecordCommandResponse> Handle(DeleteFinancialRecordCommandRequest request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}