using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class ProductTbl
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public double ProductPrice { get; set; }

    public string? ProductPicture { get; set; }

    public int AmountInStock { get; set; }

    public int CategoryId { get; set; }

    public virtual CategoryTbl Category { get; set; } = null!;

    public virtual ICollection<SaleDetailsTbl> SaleDetailsTbls { get; } = new List<SaleDetailsTbl>();
}
