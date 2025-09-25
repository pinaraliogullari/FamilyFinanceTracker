using FinancialTrack.Application.Features.User.Commands.DeleteUser;
using FinancialTrack.Core.Markers;
using MediatR;

namespace FinancialTrack.Application.Features.FinancialRecord.Commands.DeleteFinancialRecord;

public class DeleteFinancialRecordCommandRequest:IBaseCommandRequest<DeleteFinancialRecordCommandResponse>
{
    public long FinancialRecordId { get; set; }
}