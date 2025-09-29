namespace FinancialTrack.Application.Features.User.Queries.GetMyProfile;

public class GetMyProfileQueryResponse
{
    public long Id { get; set; }        
    public string FirstName { get; set; } 
    public string LastName { get; set; }     
    public string Email  { get; set; }
    public string RoleName { get; set; }
}