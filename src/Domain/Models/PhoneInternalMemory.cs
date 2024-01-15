using Core.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Models;

public class PhoneInternalMemory : Entity
{

    public string Capacity { get; set; } = null!;


    public virtual ICollection<PhoneProduct> PhoneProducts { get; set; } = new List<PhoneProduct>();
}
