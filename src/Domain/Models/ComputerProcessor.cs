using Core.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Models;

public class ComputerProcessor : BaseEntity
{
    
    public string Name { get; set; } = null!;

    public int? Gen { get; set; }

    public virtual ICollection<ComputerProduct> ComputerProducts { get; set; } = new List<ComputerProduct>();
}
