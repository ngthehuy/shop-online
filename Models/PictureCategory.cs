﻿using System;
using System.Collections.Generic;

namespace ShopOnline.Models;

public partial class PictureCategory
{
    public int PictureCategoryId { get; set; }

    public string? Avatar { get; set; }

    public string? Thumb { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public int? Position { get; set; }

    public bool? Status { get; set; }

    public DateTime? CreateTime { get; set; }

    public string? CreateBy { get; set; }

    public virtual Account? CreateByNavigation { get; set; }

    public virtual ICollection<Picture> Pictures { get; set; } = new List<Picture>();
}