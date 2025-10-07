using System;
using System.Collections.Generic;

namespace AspNetCoreWebAPI.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Sku { get; set; } = null!;

    public string? CreatedBy { get; set; }

    public string? ApprovedBy { get; set; }

    public string? RequestedBy { get; set; }

    public string Status { get; set; } = null!;

    public int CategoryId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? ApprovedAt { get; set; }

    public DateTime? RequestedAt { get; set; }

    public virtual User? ApprovedByNavigation { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual User? CreatedByNavigation { get; set; }

    public virtual Seller? RequestedByNavigation { get; set; }

    public virtual ICollection<SellerProduct> SellerProducts { get; set; } = new List<SellerProduct>();
}
