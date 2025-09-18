using MediatR;

namespace FinancialTrack.Application.Features.FinancialRecord.Commands.CreateFinancialRecord;

public class CreateFinancialRecordCommandHandler : IRequestHandler<CreateFinancialRecordCommandRequest,
    CreateFinancialRecordCommandResponse>
{
    public Task<CreateFinancialRecordCommandResponse> Handle(CreateFinancialRecordCommandRequest request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}