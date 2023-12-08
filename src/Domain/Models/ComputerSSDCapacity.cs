using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class ComputerSSDCapacity
{
    public Guid Id { get; set; }

    public string Capacity { get; set; } = null!;

    public DateOnly CreatedDate { get; set; }

    public DateOnly? UpdatedDate { get; set; }

    public DateOnly? DeletedDate { get; set; }

    public virtual ICollection<ComputerProduct> ComputerProducts { get; set; } = new List<ComputerProduct>();
}
