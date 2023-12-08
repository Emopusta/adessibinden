using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class PhoneInternalMemory
{
    public Guid Id { get; set; }

    public string Capacity { get; set; } = null!;

    public DateOnly CreatedDate { get; set; }

    public DateOnly? UpdatedDate { get; set; }

    public DateOnly? DeletedDate { get; set; }

    public virtual ICollection<PhoneProduct> PhoneProducts { get; set; } = new List<PhoneProduct>();
}
