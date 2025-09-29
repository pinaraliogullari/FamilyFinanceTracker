using System.ComponentModel.DataAnnotations.Schema;
using FinancialTrack.Domain.Entities.Common;

namespace FinancialTrack.Domain.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
    public long RoleId { get; set; }
    public ICollection<FinancialRecord> FinancialRecords { get; set; }

    //self-referencing many-to-many
    public ICollection<UserFollow> Followers { get; set; } = new List<UserFollow>();
    public ICollection<UserFollow> Following { get; set; } = new List<UserFollow>();
}