﻿using Core.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class ComputerVideoCard : BaseEntity<Guid>
{

    public string Memory { get; set; } = null!;


    public virtual ICollection<ComputerProduct> ComputerProducts { get; set; } = new List<ComputerProduct>();
}
