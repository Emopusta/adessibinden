using Core.Domain.Entities;

namespace Domain.Models;

public class ComputerOperatingSystem : Entity
{
    public string Name { get; set; } = null!;

    public virtual ICollection<ComputerProduct> ComputerProducts { get; set; } = new List<ComputerProduct>();
}
