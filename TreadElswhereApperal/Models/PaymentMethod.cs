using System;
using System.Collections.Generic;

namespace TreadElswhereApperal.Models;

public partial class PaymentMethod
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public string? BillingAddress { get; set; }

    public int? CardNumber { get; set; }

    public DateOnly? ExpirationDate { get; set; }

    public int? Csv { get; set; }

    public string? PaymentProvider { get; set; }

    public string? PaymentType { get; set; }

    public virtual Customer? Customer { get; set; }
}
