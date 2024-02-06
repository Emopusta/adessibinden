using Core.DataAccess.Entities;

namespace Domain.Models;

public class CarFuelType : Entity
{
    public string Name { get; set; } = null!;

    public virtual ICollection<CarProduct> CarProducts { get; set; } = new List<CarProduct>();
}
