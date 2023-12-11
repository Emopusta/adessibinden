using Core.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class PhoneProduct : BaseEntity<Guid>
{
    public Guid ProductId { get; set; }

    public Guid ColorId { get; set; }

    public Guid ModelId { get; set; }

    public Guid InternalMemoryId { get; set; }

    public Guid RAMId { get; set; }

    public bool UsageStatus { get; set; }

    public decimal Price { get; set; }

    public virtual Color Color { get; set; } = null!;

    public virtual PhoneInternalMemory InternalMemory { get; set; } = null!;

    public virtual PhoneModel Model { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual PhoneRAM RAM { get; set; } = null!;
}
