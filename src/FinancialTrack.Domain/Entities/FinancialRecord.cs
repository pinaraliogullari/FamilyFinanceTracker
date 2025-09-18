using FinancialTrack.Domain.Entities.Common;

namespace FinancialTrack.Domain.Entities;

public class FinancialRecord : BaseEntity
{
    public decimal Amount { get; set; }
    public Guid SubCategoryId { get; set; }
    public SubCategory SubCategory { get; set; }
    public string Description { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
}