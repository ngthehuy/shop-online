using System;
using System.Collections.Generic;

namespace ShopOnline.Models;

public partial class ProductVote
{
    public int ClientId { get; set; }

    public int ProductId { get; set; }

    public DateTime? CreateTime { get; set; }

    public int? Value { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
