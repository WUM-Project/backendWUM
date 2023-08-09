﻿using System;
using System.Collections.Generic;

namespace ProductsService.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int? ParentCategoryId { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}