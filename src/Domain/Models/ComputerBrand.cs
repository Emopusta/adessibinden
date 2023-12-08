﻿using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class ComputerBrand
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly CreatedDate { get; set; }

    public DateOnly? UpdatedDate { get; set; }

    public DateOnly? DeletedDate { get; set; }

    public virtual ICollection<ComputerProduct> ComputerProducts { get; set; } = new List<ComputerProduct>();
}
