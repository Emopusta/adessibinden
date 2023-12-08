using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class UserProfile
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Address { get; set; }

    public DateOnly? BirthDate { get; set; }

    public DateOnly CreatedDate { get; set; }

    public DateOnly? UpdatedDate { get; set; }

    public DateOnly? DeletedDate { get; set; }

    public virtual User User { get; set; } = null!;
}
