using Core.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Models;

public class Color : Entity
{ //partial yapıp business ayırmayı araştır

    public string Name { get; set; } = null!;

    public virtual ICollection<CarProduct> CarProducts { get; set; } = new List<CarProduct>();

    public virtual ICollection<PhoneProduct> PhoneProducts { get; set; } = new List<PhoneProduct>();

}
