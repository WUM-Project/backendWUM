using System;
using System.Collections.Generic;

namespace ProductsService.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int CategoryId { get; set; }

    public float? Price { get; set; }

    public string? Code { get; set; }

    public int? ManufacturerId { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Category Category { get; set; } = null!;

    public virtual Manufacturer? Manufacturer { get; set; }
}
