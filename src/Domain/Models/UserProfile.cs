using Core.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Models;

public class UserProfile : Entity
{
    public int UserId { get; set; }

    public string? FirstName { get; set; } = null!;

    public string? LastName { get; set; } = null!;

    public string? Address { get; set; }

    public DateTime? BirthDate { get; set; }

    public virtual User User { get; set; } = null!;
}
