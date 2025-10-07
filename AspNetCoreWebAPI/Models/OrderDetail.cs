using System;
using System.Collections.Generic;

namespace AspNetCoreWebAPI.Models;

public partial class OrderDetail
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int SellerProductsId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public DateOnly? ShippingDate { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual SellerProduct SellerProducts { get; set; } = null!;
}
