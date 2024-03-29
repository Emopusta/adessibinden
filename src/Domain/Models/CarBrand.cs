﻿using Core.Domain.Entities;

namespace Domain.Models;

public class CarBrand : Entity
{
    public string Name { get; set; } = null!;
    public virtual ICollection<CarModel> CarModels { get; set; } = new List<CarModel>();
    public CarBrand() { }
    public CarBrand(string name, int id)
    {
        Id = id;
        Name = name;
    }
}
