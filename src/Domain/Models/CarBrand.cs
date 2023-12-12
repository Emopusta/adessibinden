using Core.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
namespace Domain.Models;

public partial class CarBrand : BaseEntity<Guid>
{
    public string Name { get; set; } = null!;
    public virtual ICollection<CarModel> CarModels { get; set; } = new List<CarModel>();
}
