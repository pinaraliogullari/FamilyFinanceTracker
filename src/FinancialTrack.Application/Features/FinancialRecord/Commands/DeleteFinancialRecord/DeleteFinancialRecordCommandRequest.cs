using FinancialTrack.Application.Features.User.Commands.DeleteUser;
using MediatR;

namespace FinancialTrack.Application.Features.FinancialRecord.Commands.DeleteFinancialRecord;

public class DeleteFinancialRecordCommandRequest:IRequest<DeleteFinancialRecordCommandResponse>
{
    public long FinancialRecordId { get; set; }
}