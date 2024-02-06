using Core.DataAccess.Entities;

namespace Domain.Models;

public class PhoneInternalMemory : Entity
{
    public string Capacity { get; set; } = null!;

    public virtual ICollection<PhoneProduct> PhoneProducts { get; set; } = new List<PhoneProduct>();
}
