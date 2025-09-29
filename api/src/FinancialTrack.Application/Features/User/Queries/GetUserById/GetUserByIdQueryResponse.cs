namespace FinancialTrack.Application.Features.User.Queries.GetUserById;

public class GetUserByIdQueryResponse
{
    public long Id { get; set; }        
    public string FirstName { get; set; } 
    public string LastName { get; set; }     
    public string Email  { get; set; }
    public string RoleName { get; set; }
    public long RoleId  { get; set; }
}