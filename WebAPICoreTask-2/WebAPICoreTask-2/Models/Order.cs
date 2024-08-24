using System;
using System.Collections.Generic;

namespace WebAPICoreTask_2.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public string? OrderName { get; set; }

    public int? UserId { get; set; }

    public DateOnly? OrderDate { get; set; }

    public virtual ICollection<OrderTable> OrderTables { get; set; } = new List<OrderTable>();

    public virtual User? User { get; set; }
}
