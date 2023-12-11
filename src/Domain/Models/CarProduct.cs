using Core.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class CarProduct : BaseEntity<Guid>
{
  

    public Guid ProductId { get; set; }

    public Guid CarProductCategoryId { get; set; }

    public Guid ColorId { get; set; }

    public Guid ModelId { get; set; }

    public Guid FuelTypeId { get; set; }

    public Guid ChassisTypeId { get; set; }

    public int Kilometer { get; set; }

    public short Gear { get; set; }

    public bool Status { get; set; }

    public short EnginePower { get; set; }

    public short EngineDisplacement { get; set; }

    public bool Warranty { get; set; }


    public virtual CarProductCategory CarProductCategory { get; set; } = null!;

    public virtual CarChassisType ChassisType { get; set; } = null!;

    public virtual Color Color { get; set; } = null!;

    public virtual CarFuelType FuelType { get; set; } = null!;

    public virtual CarModel Model { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
