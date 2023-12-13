using Core.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Models;

public class CarModel : BaseEntity
{
   

    public int BrandId { get; set; }

    public string Name { get; set; } = null!;

    public int ModelYear { get; set; }

    public virtual CarBrand Brand { get; set; } = null!;

    public virtual ICollection<CarProduct> CarProducts { get; set; } = new List<CarProduct>();
}
