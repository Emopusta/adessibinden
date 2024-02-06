using Core.DataAccess.Entities;

namespace Domain.Models;

public class ComputerProduct : Entity
{
    public int ProductId { get; set; }
    public int BrandId { get; set; }
    public int RAMId { get; set; }
    public int VideoCardId { get; set; }
    public int ProcessorId { get; set; }
    public int SSDCapacityId { get; set; }
    public int OperatingSystemId { get; set; }

    public virtual ComputerBrand Brand { get; set; } = null!;
    public virtual ComputerOperatingSystem OperatingSystem { get; set; } = null!;
    public virtual ComputerProcessor Processor { get; set; } = null!;
    public virtual Product Product { get; set; } = null!;
    public virtual ComputerRAM RAM { get; set; } = null!;
    public virtual ComputerSSDCapacity SSDCapacity { get; set; } = null!;
    public virtual ComputerVideoCard VideoCard { get; set; } = null!;
}
