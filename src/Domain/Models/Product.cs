using Core.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Product : BaseEntity<Guid>
{
    
    public Guid CreatorUserId { get; set; }

    public Guid ProductCategoryId { get; set; }


    public virtual ICollection<CarProduct> CarProducts { get; set; } = new List<CarProduct>();

    public virtual ICollection<ComputerProduct> ComputerProducts { get; set; } = new List<ComputerProduct>();

    public virtual User CreatorUser { get; set; } = null!;

    public virtual ICollection<PhoneProduct> PhoneProducts { get; set; } = new List<PhoneProduct>();

    public virtual ProductCategory ProductCategory { get; set; } = null!;

    public virtual ICollection<UserFavouriteProduct> UserFavouriteProducts { get; set; } = new List<UserFavouriteProduct>();
}
