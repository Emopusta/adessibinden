using Core.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Models;

public class PhoneModel : BaseEntity
{
    public int BrandId { get; set; }

    public string Name { get; set; } = null!;

    public virtual PhoneBrand Brand { get; set; } = null!;

    public virtual ICollection<PhoneProduct> PhoneProducts { get; set; } = new List<PhoneProduct>();
}
