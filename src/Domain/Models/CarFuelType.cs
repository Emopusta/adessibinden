using Core.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class CarFuelType : BaseEntity<Guid>
{
  

    public string Name { get; set; } = null!;



    public virtual ICollection<CarProduct> CarProducts { get; set; } = new List<CarProduct>();
}
