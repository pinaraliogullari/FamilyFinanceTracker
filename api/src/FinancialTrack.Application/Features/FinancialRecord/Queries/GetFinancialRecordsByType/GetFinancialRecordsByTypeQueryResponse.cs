namespace FinancialTrack.Application.Features.FinancialRecord.Queries.GetFinancialRecordsByType;

public class GetFinancialRecordsByTypeQueryResponse
{
    public long FinancialRecordId { get; set; }
    public decimal Amount { get; set; }
    public long CategoryId { get; set; }
    public string CategoryName { get; set; } 
    public string Description { get; set; }
    public string FinancialRecordType { get; set; }
    public long UserId { get; set; }
    public string UserFirstName { get; set; }
    public string UserLastName { get; set; } 
}