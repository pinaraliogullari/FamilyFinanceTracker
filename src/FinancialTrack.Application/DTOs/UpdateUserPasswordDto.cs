namespace FinancialTrack.Application.DTOs;

public class UpdateUserPasswordDto
{
    public long UserId  { get; set; }
    public string OldPassword { get; set; }
    public string NewPassword  { get; set; }
    public string NewPasswordConfirm { get; set; }
   
}