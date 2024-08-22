using System;
using System.Collections.Generic;

namespace ShopOnline.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public string? FullName { get; set; }

    public string? Mobile { get; set; }

    public string? Address { get; set; }

    public double? Total { get; set; }

    public double? Bonus { get; set; }

    public double? Amount { get; set; }

    public DateTime? CreateTime { get; set; }

    public bool? OrderStatus { get; set; }

    public bool? ConfirmStatus { get; set; }

    public bool? ChargeStatus { get; set; }

    public bool? DeliveStatus { get; set; }

    public int? ClientId { get; set; }

    public virtual Client? Client { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
