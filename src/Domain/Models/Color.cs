using Core.DataAccess.Entities;

namespace Domain.Models;

public class Color : Entity
{
    public string Name { get; set; } = null!;

    public virtual ICollection<CarProduct> CarProducts { get; set; } = new List<CarProduct>();
    public virtual ICollection<PhoneProduct> PhoneProducts { get; set; } = new List<PhoneProduct>();
}
