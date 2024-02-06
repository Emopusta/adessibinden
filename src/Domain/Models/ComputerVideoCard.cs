using Core.DataAccess.Entities;

namespace Domain.Models;

public class ComputerVideoCard : Entity
{
    public string Memory { get; set; } = null!;

    public virtual ICollection<ComputerProduct> ComputerProducts { get; set; } = new List<ComputerProduct>();
}
