using Core.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class PhoneRAM : BaseEntity<Guid>
{

    public string Memory { get; set; } = null!;

    public virtual ICollection<PhoneProduct> PhoneProducts { get; set; } = new List<PhoneProduct>();
}
