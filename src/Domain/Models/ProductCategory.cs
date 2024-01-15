using Core.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Models;

public class ProductCategory : Entity
{
    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
