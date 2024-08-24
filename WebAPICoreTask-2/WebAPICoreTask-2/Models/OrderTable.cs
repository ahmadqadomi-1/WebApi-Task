using System;
using System.Collections.Generic;

namespace WebAPICoreTask_2.Models;

public partial class OrderTable
{
    public int OrderTable1 { get; set; }

    public int? OrderId { get; set; }

    public int? UserId { get; set; }

    public virtual Order? Order { get; set; }

    public virtual User? User { get; set; }
}
