using Core.DataAccess.Entities;

namespace Domain.Models;

public class UserFavouriteProduct : BaseEntity
{

    public int ProductId { get; set; }

    public int UserId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
