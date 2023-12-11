﻿using Core.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class ComputerProduct : BaseEntity<Guid>
{

    public Guid ProductId { get; set; }

    public Guid BrandId { get; set; }

    public Guid RAMId { get; set; }

    public Guid VideoCardId { get; set; }

    public Guid ProcessorId { get; set; }

    public Guid SSDCapacityId { get; set; }

    public Guid OperatingSystemId { get; set; }

    public virtual ComputerBrand Brand { get; set; } = null!;

    public virtual ComputerOperatingSystem OperatingSystem { get; set; } = null!;

    public virtual ComputerProcessor Processor { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual ComputerRAM RAM { get; set; } = null!;

    public virtual ComputerSSDCapacity SSDCapacity { get; set; } = null!;

    public virtual ComputerVideoCard VideoCard { get; set; } = null!;
}
