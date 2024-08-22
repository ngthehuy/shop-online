using System;
using System.Collections.Generic;

namespace ShopOnline.Models;

public partial class Client
{
    public int ClientId { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? FullName { get; set; }

    public string? Mobile { get; set; }

    public string? Address { get; set; }

    public bool? Status { get; set; }

    public DateTime? CreateTime { get; set; }

    public int? ClientCategoryId { get; set; }

    public virtual ClientCategory? ClientCategory { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<ProductComment> ProductComments { get; set; } = new List<ProductComment>();

    public virtual ICollection<ProductVote> ProductVotes { get; set; } = new List<ProductVote>();
}
