using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class CarProductCategory
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly CreatedDate { get; set; }

    public DateOnly? UpdatedDate { get; set; }

    public DateOnly? DeletedDate { get; set; }

    public virtual ICollection<CarProduct> CarProducts { get; set; } = new List<CarProduct>();
}
