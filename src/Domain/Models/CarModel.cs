using Core.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class CarModel : BaseEntity<Guid>
{
   

    public Guid BrandId { get; set; }

    public string Name { get; set; } = null!;

    public short ModelYear { get; set; }

    public virtual CarBrand Brand { get; set; } = null!;

    public virtual ICollection<CarProduct> CarProducts { get; set; } = new List<CarProduct>();
}
