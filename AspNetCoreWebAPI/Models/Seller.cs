using System;
using System.Collections.Generic;

namespace AspNetCoreWebAPI.Models;

public partial class Seller
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string SellerType { get; set; } = null!;

    public string? CompanyName { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<SellerProduct> SellerProducts { get; set; } = new List<SellerProduct>();
}
