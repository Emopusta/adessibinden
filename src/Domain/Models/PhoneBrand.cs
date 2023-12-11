using Core.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class PhoneBrand : BaseEntity<Guid>
{
  

    public string Name { get; set; } = null!;



    public virtual ICollection<PhoneModel> PhoneModels { get; set; } = new List<PhoneModel>();
}
