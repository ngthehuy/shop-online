using System;
using System.Collections.Generic;

namespace ShopOnline.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? Avatar { get; set; }

    public string? Thumb { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Specification { get; set; }

    public string? Content { get; set; }

    public string? Warranty { get; set; }

    public string? Accessories { get; set; }

    public double? Price { get; set; }

    public double? OldPrice { get; set; }

    public int? Quantity { get; set; }

    public string? ImageList { get; set; }

    public int? Position { get; set; }

    public bool? Status { get; set; }

    public DateTime? CreateTime { get; set; }

    public int? ProductCategoryId { get; set; }

    public string? CreateBy { get; set; }

    public virtual Account? CreateByNavigation { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ProductCategory? ProductCategory { get; set; }

    public virtual ICollection<ProductComment> ProductComments { get; set; } = new List<ProductComment>();

    public virtual ICollection<ProductVote> ProductVotes { get; set; } = new List<ProductVote>();
}
