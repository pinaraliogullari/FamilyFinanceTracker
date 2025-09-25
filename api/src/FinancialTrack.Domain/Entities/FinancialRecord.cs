using FinancialTrack.Domain.Entities.Common;

namespace FinancialTrack.Domain.Entities;

public class FinancialRecord : BaseEntity
{
    public decimal Amount { get; set; }
    public long CategoryId { get; set; }
    public Category Category { get; set; }
    public string Description { get; set; }
    public User User { get; set; }
    public long UserId { get; set; }
 
}