using System;
using System.Collections.Generic;

namespace WebAPICoreTask_3.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public int? RapperId { get; set; }

    public int? TrackId { get; set; }

    public virtual PlayList? PlayList { get; set; }

    public virtual Rapper? Rapper { get; set; }

    public virtual Track? Track { get; set; }
}
