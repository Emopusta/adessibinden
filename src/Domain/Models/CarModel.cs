using Core.DataAccess.Entities;

namespace Domain.Models;

public class CarModel : Entity
{
    public int BrandId { get; set; }
    public string Name { get; set; } = null!;
    public int ModelYear { get; set; }

    public virtual CarBrand Brand { get; set; } = null!;
    public virtual ICollection<CarProduct> CarProducts { get; set; } = new List<CarProduct>();
}
