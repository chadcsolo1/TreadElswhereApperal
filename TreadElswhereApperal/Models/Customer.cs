using System;
using System.Collections.Generic;

namespace TreadElswhereApperal.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Salt { get; set; }

    public string? Address { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public DateTime? AccountCreated { get; set; }

    public DateTime? AccountUpdated { get; set; }

    public string? AccountStatus { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<PaymentMethod> PaymentMethods { get; set; } = new List<PaymentMethod>();
}
