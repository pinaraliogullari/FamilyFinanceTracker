using FinancialTrack.Domain.Entities.Common;
using FinancialTrack.Domain.Entities.Enums;

namespace FinancialTrack.Domain.Entities;

public class FinancialRecord : BaseEntity
{
    public FinancialRecordType FinancialRecordType { get; set; }
    public decimal Amount { get; set; }
    public long CategoryId { get; set; }
    public Category Category { get; set; }
    public string Description { get; set; }
    public User User { get; set; }
    public long UserId { get; set; }
 
}