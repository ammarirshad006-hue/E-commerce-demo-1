using System;
using System.Collections.Generic;

namespace AspNetCoreWebAPI.Models;

public partial class SellerProduct
{
    public int Id { get; set; }

    public int? SellerId { get; set; }

    public int? ProductId { get; set; }

    public DateOnly ListingDate { get; set; }

    public decimal? Price { get; set; }

    public int? QuantityAvailable { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Product? Product { get; set; }

    public virtual Seller? Seller { get; set; }
}
