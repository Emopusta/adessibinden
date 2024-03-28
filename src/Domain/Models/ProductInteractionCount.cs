using Core.Domain.Entities;

namespace Domain.Models;
public class ProductInteractionCount : Entity
{
    public int ProductId { get; set; }
    public int Count { get; set; }


    public virtual Product Product { get; set; }
}
