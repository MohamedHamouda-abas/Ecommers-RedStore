using System;
using System.Collections.Generic;

namespace RedStore.Models;

public partial class TbFeatured
{
    public int FeaturedId { get; set; }

    public string? ProductName { get; set; }

    public decimal? SalesPrice { get; set; }

    public decimal? PurchasePrice { get; set; }

    public string? Prand { get; set; }

    public string? ImageName { get; set; }

    public string? Rating { get; set; }

    public string? Size { get; set; }

    public string? Qty { get; set; }

    public string? Pragraph { get; set; }

    public decimal? Subtotal { get; set; }

    public decimal? Tax { get; set; }

    public decimal? Total { get; set; }
    public int? CurrentState { get; set; }

}
