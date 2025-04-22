using System;
using System.Collections.Generic;

namespace TreadElswhereApperal.Models;

public partial class Order
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? DateCreated { get; set; } = DateTime.UtcNow;

    public string? OrderStatus { get; set; } = "Pending";

    public string? PaymentStatus { get; set; } = "None";

    public string? PaymentMethod { get; set; }

    public DateTime? PaymentDate { get; set; } = DateTime.UtcNow;

    public decimal? TotalAmount { get; set; }

    public decimal? PricePerUnit { get; set; }

    public int? Quantity { get; set; }

    public decimal? Subtotal { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
