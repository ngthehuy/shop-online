using System;
using System.Collections.Generic;

namespace ShopOnline.Models;

public partial class Account
{
    public string Username { get; set; } = null!;

    public string? Password { get; set; }

    public string? Avatar { get; set; }

    public string? Thumb { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Mobile { get; set; }

    public string? Address { get; set; }

    public bool? Status { get; set; }

    public DateTime? CreateTime { get; set; }

    public string? AccountCategoryId { get; set; }

    public virtual AccountCategory? AccountCategory { get; set; }

    public virtual ICollection<ArticleCategory> ArticleCategories { get; set; } = new List<ArticleCategory>();

    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();

    public virtual ICollection<ClientCategory> ClientCategories { get; set; } = new List<ClientCategory>();

    public virtual ICollection<ContactCategory> ContactCategories { get; set; } = new List<ContactCategory>();

    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();

    public virtual ICollection<PictureCategory> PictureCategories { get; set; } = new List<PictureCategory>();

    public virtual ICollection<Picture> Pictures { get; set; } = new List<Picture>();

    public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();

    public virtual ICollection<ProductMainCategory> ProductMainCategories { get; set; } = new List<ProductMainCategory>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
