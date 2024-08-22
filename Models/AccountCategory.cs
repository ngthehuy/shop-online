using System;
using System.Collections.Generic;

namespace ShopOnline.Models;

public partial class AccountCategory
{
    public string AccountCategoryId { get; set; } = null!;

    public string? Title { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
