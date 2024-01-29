using System;
using System.Collections.Generic;

namespace main_prj.Models;

public partial class CategoryProduct
{
    public int CatePrdId { get; set; }

    public int? CategoryId { get; set; }

    public int? ProductId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Product? Product { get; set; }
}
