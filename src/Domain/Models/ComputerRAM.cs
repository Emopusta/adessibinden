using Core.Domain.Entities;

namespace Domain.Models;

public class ComputerRAM : Entity
{
    public string Memory { get; set; } = null!;

    public virtual ICollection<ComputerProduct> ComputerProducts { get; set; } = new List<ComputerProduct>();
}
