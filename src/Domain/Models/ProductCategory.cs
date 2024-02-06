using Core.DataAccess.Entities;

namespace Domain.Models;

public class ProductCategory : Entity
{
    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
