using System;
using System.Collections.Generic;

namespace AspNetCoreWebAPI.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Email { get; set; }

    public string PasswordHash { get; set; } = null!;

    public int RoleId { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Product> ProductApprovedByNavigations { get; set; } = new List<Product>();

    public virtual ICollection<Product> ProductCreatedByNavigations { get; set; } = new List<Product>();

    public virtual Role Role { get; set; } = null!;
}
