using FinancialTrack.Core.Markers;

namespace FinancialTrack.Application.Features.FinancialRecord.Commands.UpdateFinancialRecord;

public class UpdateFinancialRecordCommandRequest : IBaseCommandRequest<UpdateFinancialRecordCommandResponse>
{
    public long FinancialRecordId { get; set; }
    public decimal? Amount { get; set; }
    public long? CategoryId { get; set; }
    public string? Description { get; set; }
    public long? UserId { get; set; }
}