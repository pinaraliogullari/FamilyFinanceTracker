using FinancialTrack.Domain.Entities.Common;
using FinancialTrack.Domain.Entities.Enums;

namespace FinancialTrack.Domain.Entities;

public class SubCategory : BaseEntity
{
    public bool IsCustom { get; set; }
    public Guid MainCategoryId { get; set; }
    public MainCategory MainCategory { get; set; }
    public Guid CreatedByUserId { get; set; }
    public User CreatedByUser { get; set; }
    public ICollection<FinancialRecord> FinancialRecords { get; set; }
}