using Core.Domain.Entities;

namespace Domain.Models;

public class ComputerProcessor : Entity
{
    public string Name { get; set; } = null!;
    public int? Gen { get; set; }

    public virtual ICollection<ComputerProduct> ComputerProducts { get; set; } = new List<ComputerProduct>();
}
