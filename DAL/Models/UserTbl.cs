using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class UserTbl
{
    public string UserId { get; set; } = null!;

    public string UserFirstName { get; set; } = null!;

    public string UserLastName { get; set; } = null!;

    public string UserAddress { get; set; } = null!;

    public string UserEmail { get; set; } = null!;

    public string UserPhone { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public virtual ICollection<SalesTbl> SalesTbls { get; } = new List<SalesTbl>();
}
