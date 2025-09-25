using MediatR;

namespace FinancialTrack.Application.Features.FinancialRecord.Commands.CreateFinancialRecord;

public class CreateFinancialRecordCommandRequest : IRequest<CreateFinancialRecordCommandResponse>
{
    public decimal Amount { get; set; }
    public long CategoryId { get; set; }
    public string Description { get; set; }
    public long UserId { get; set; }
}