using Core.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Models;

public class PhoneBrand : BaseEntity
{
  
    public string Name { get; set; } = null!;

    public virtual ICollection<PhoneModel> PhoneModels { get; set; } = new List<PhoneModel>();
}
