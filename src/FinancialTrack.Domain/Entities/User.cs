using System.ComponentModel.DataAnnotations.Schema;
using FinancialTrack.Domain.Entities.Common;

namespace FinancialTrack.Domain.Entities;

public class User : BaseEntity
{
    [NotMapped] 
    public override string Name { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}