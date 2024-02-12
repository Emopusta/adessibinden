using Core.Domain.Entities;

namespace Domain.Models;

public class PhoneRAM : Entity
{
    public string Memory { get; set; } = null!;

    public virtual ICollection<PhoneProduct> PhoneProducts { get; set; } = new List<PhoneProduct>();
}
