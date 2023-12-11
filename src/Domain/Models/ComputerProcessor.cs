using Core.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class ComputerProcessor : BaseEntity<Guid>
{
    
    public string Name { get; set; } = null!;

    public short? Gen { get; set; }

    public virtual ICollection<ComputerProduct> ComputerProducts { get; set; } = new List<ComputerProduct>();
}
