using FinancialTrack.Domain.Entities.Common;

namespace FinancialTrack.Domain.Entities;

public class Role : BaseEntity
{
    public string Name { get; set; }
    public ICollection<User> Users { get; set; }
}