using System;
using System.Collections.Generic;

namespace ShopOnline.Models;

public partial class ProductComment
{
    public int ProductCommentId { get; set; }

    public string? Content { get; set; }

    public bool? Status { get; set; }

    public DateTime? CreateTime { get; set; }

    public int? ClientId { get; set; }

    public int? ProductId { get; set; }

    public virtual Client? Client { get; set; }

    public virtual Product? Product { get; set; }
}
