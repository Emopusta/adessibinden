using Core.DataAccess.Entities;

namespace Domain.Models;

public class Product : Entity
{   
    public int CreatorUserId { get; set; }
    public int ProductCategoryId { get; set; }
    public string Description { get; set; }
    public string Title { get; set; }

    public virtual ICollection<CarProduct> CarProducts { get; set; } = new List<CarProduct>();
    public virtual ICollection<ComputerProduct> ComputerProducts { get; set; } = new List<ComputerProduct>();
    public virtual User CreatorUser { get; set; } = null!;
    public virtual ICollection<PhoneProduct> PhoneProducts { get; set; } = new List<PhoneProduct>();
    public virtual ProductCategory ProductCategory { get; set; } = null!;
    public virtual ICollection<UserFavouriteProduct> UserFavouriteProducts { get; set; } = new List<UserFavouriteProduct>();
}
