using FinancialTrack.Core.Markers;
using FinancialTrack.Domain.Entities.Enums;
using MediatR;

namespace FinancialTrack.Application.Features.FinancialRecord.Commands.CreateFinancialRecord;

public class CreateFinancialRecordCommandRequest : IBaseCommandRequest<CreateFinancialRecordCommandResponse>
{
    public decimal Amount { get; set; }
    public long CategoryId { get; set; }
    public string Description { get; set; }
    public FinancialRecordType FinancialRecordType{ get; set; }
    
}