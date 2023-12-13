using Core.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
namespace Domain.Models;

public class CarBrand : BaseEntity<int>
{
    public string Name { get; set; } = null!;
    public virtual ICollection<CarModel> CarModels { get; set; } = new List<CarModel>();

    public CarBrand()
    {
    }

    public CarBrand(string name, int id)
    {
        Id = id;
        Name = name;
    }
}
