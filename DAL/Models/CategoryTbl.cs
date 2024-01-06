using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class CategoryTbl
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<ProductTbl> ProductTbls { get; } = new List<ProductTbl>();
}
