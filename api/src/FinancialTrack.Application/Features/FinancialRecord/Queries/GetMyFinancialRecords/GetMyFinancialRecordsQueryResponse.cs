namespace FinancialTrack.Application.Features.FinancialRecord.Queries.GetMyFinancialRecords;

public class GetMyFinancialRecordsQueryResponse
{
    public long FinancialRecordId { get; set; }
    public decimal Amount { get; set; }
    public long CategoryId { get; set; }
    public string CategoryName { get; set; } 
    public string Description { get; set; }
    public string FinancialRecordType { get; set; }
}