using Core.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Models;

public class PhoneProduct : Entity
{
    public int ProductId { get; set; }

    public int ColorId { get; set; }

    public int ModelId { get; set; }

    public int InternalMemoryId { get; set; }

    public int RAMId { get; set; }

    public bool UsageStatus { get; set; }

    public decimal Price { get; set; }

    public virtual Color Color { get; set; } = null!;

    public virtual PhoneInternalMemory InternalMemory { get; set; } = null!;

    public virtual PhoneModel Model { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual PhoneRAM RAM { get; set; } = null!;
}
