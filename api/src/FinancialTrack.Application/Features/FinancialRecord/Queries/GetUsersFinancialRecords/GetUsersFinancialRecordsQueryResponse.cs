namespace FinancialTrack.Application.Features.FinancialRecord.Queries.GetUsersFinancialRecords;

public class GetUsersFinancialRecordsQueryResponse
{
    public long FinancialRecordId { get; set; }
    public decimal Amount { get; set; }
    public long CategoryId { get; set; }
    public string Description { get; set; }
    public long UserId { get; set; }  
}