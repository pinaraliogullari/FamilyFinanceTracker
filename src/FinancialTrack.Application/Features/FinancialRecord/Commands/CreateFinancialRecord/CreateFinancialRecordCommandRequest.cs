using FinancialTrack.Application.Features.User.Commands.CreateUser;
using FinancialTrack.Application.Wrappers;
using MediatR;

namespace FinancialTrack.Application.Features.FinancialRecord.Commands.CreateFinancialRecord;

public class CreateFinancialRecordCommandRequest : IRequest<ApiResult<CreateFinancialRecordCommandResponse>>
{
    public decimal Amount { get; set; }
    public long CategoryId { get; set; }
    public string Description { get; set; }
    public long UserId { get; set; }
}