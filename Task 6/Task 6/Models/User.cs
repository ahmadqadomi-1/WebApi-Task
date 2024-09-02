using System;
using System.Collections.Generic;

namespace Task_6.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public int? ProductId { get; set; }

    public int? CategoryId { get; set; }

    public virtual Cart? Cart { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Product? Product { get; set; }
}
