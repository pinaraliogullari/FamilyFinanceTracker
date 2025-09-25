using FinancialTrack.Application.DTOs;

namespace FinancialTrack.Application.Features.User.Queries.GetAllUsers;

public class GetAllUsersQueryResponse
{
    public long Id { get; set; }        
    public string Firstname { get; set; } 
    public string Lastname { get; set; }     
    public string Email  { get; set; }
    public string RoleName { get; set; }   
}