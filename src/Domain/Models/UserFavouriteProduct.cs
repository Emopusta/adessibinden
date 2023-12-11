using Core.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class UserFavouriteProduct : BaseEntity<Guid>
{

    public Guid ProductId { get; set; }

    public Guid UserId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
