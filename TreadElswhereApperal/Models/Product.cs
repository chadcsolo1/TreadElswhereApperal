using System;
using System.Collections.Generic;

namespace TreadElswhereApperal.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string ProductDescription { get; set; } = null!;

    public double Price { get; set; }

    public int StockQuantity { get; set; }

    public bool IsActive { get; set; }

    public bool ShowProperties { get; set; }

    public DateOnly AvailableAfter { get; set; }

    public string Styles { get; set; } = null!;

    public string Sizes { get; set; } = null!;

    public string Colors { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
