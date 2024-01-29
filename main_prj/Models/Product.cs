using System;
using System.Collections.Generic;

namespace main_prj.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public decimal Price { get; set; }

    public int StockQuantity { get; set; }

    public string? ProductDescription { get; set; }

    public string? ProductImages { get; set; }

    public int? Warranty { get; set; }

    public virtual ICollection<CategoryProduct> CategoryProducts { get; set; } = new List<CategoryProduct>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
