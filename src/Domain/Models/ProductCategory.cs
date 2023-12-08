using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class ProductCategory
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly CreatedDate { get; set; }

    public DateOnly? UpdatedDate { get; set; }

    public DateOnly? DeletedDate { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
