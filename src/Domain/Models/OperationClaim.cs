using Core.DataAccess.Entities;

namespace Domain.Models;

public class OperationClaim : BaseEntity
{
    public string Name { get; set; }

    public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; } = null!;

    public OperationClaim()
    {
        Name = string.Empty;
    }

    public OperationClaim(string name)
    {
        Name = name;
    }

    public OperationClaim(int id, string name)  
    {
        Id = id;
        Name = name;
    }
}
