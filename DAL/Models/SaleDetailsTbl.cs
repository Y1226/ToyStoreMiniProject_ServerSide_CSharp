using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class SaleDetailsTbl
{
    public int SaleDetailsId { get; set; }

    public int SaleId { get; set; }

    public int ProductId { get; set; }

    public int ProductCount { get; set; }

    public virtual ProductTbl Product { get; set; } = null!;

    public virtual SalesTbl Sale { get; set; } = null!;
}
