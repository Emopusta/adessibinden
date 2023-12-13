using Core.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Models;

public class CarProduct : BaseEntity<int>
{
  

    public int ProductId { get; set; }

    public int CarProductCategoryId { get; set; }

    public int ColorId { get; set; }

    public int ModelId { get; set; }

    public int FuelTypeId { get; set; }

    public int ChassisTypeId { get; set; }

    public int Kilometer { get; set; }

    public int Gear { get; set; }

    public bool Status { get; set; }

    public int EnginePower { get; set; }

    public int EngineDisplacement { get; set; }

    public bool Warranty { get; set; }


    public virtual CarProductCategory CarProductCategory { get; set; } = null!;

    public virtual CarChassisType ChassisType { get; set; } = null!;

    public virtual Color Color { get; set; } = null!;

    public virtual CarFuelType FuelType { get; set; } = null!;

    public virtual CarModel Model { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
