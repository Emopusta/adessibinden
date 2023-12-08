using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class CarModel
{
    public Guid Id { get; set; }

    public Guid BrandId { get; set; }

    public string Name { get; set; } = null!;

    public short ModelYear { get; set; }

    public DateOnly CreatedDate { get; set; }

    public DateOnly? UpdatedDate { get; set; }

    public DateOnly? DeletedDate { get; set; }

    public virtual CarBrand Brand { get; set; } = null!;

    public virtual ICollection<CarProduct> CarProducts { get; set; } = new List<CarProduct>();
}
