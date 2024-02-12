using Core.Domain.Entities;

namespace Domain.Models;

public class UserProfile : Entity
{
    public int UserId { get; set; }
    public string? FirstName { get; set; } = null!;
    public string? LastName { get; set; } = null!;
    public string? Address { get; set; }
    public DateTime? BirthDate { get; set; }

    public virtual User User { get; set; } = null!;
}
