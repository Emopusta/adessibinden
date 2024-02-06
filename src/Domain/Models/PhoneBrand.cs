using Core.DataAccess.Entities;

namespace Domain.Models;

public class PhoneBrand : Entity
{
    public string Name { get; set; } = null!;

    public virtual ICollection<PhoneModel> PhoneModels { get; set; } = new List<PhoneModel>();
}
