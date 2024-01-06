using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class SalesTbl
{
    public int SaleId { get; set; }

    public string UserId { get; set; } = null!;

    public DateTime SaleDate { get; set; }

    public double FinalPrice { get; set; }

    public virtual ICollection<SaleDetailsTbl> SaleDetailsTbls { get; } = new List<SaleDetailsTbl>();

    public virtual UserTbl User { get; set; } = null!;
}
