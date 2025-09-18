using FinancialTrack.Domain.Entities.Common;
using FinancialTrack.Domain.Entities.Enums;

namespace FinancialTrack.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public bool IsCustom { get; set; }
    public FinancialRecordType FinancialRecordType { get; set; }
    public ICollection<FinancialRecord> FinancialRecords { get; set; }
}