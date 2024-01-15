using Core.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Models;

public class ComputerSSDCapacity : Entity
{
    public string Capacity { get; set; } = null!;

    public virtual ICollection<ComputerProduct> ComputerProducts { get; set; } = new List<ComputerProduct>();
}
