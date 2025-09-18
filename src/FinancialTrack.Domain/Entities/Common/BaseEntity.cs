namespace FinancialTrack.Domain.Entities.Common;

public abstract class BaseEntity
{
    public long Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public long CreatedById { get; set; }
    public long UpdatedById { get; set; }
}