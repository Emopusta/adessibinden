using Core.Domain.Entities;

namespace Domain.Models;

public class CarChassisType : Entity
{
    public string Name { get; set; } = null!;

    public virtual ICollection<CarProduct> CarProducts { get; set; } = new List<CarProduct>();
}
