using Core.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class ProductCategory : BaseEntity<Guid>
{
    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
