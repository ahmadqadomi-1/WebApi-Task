using System;
using System.Collections.Generic;

namespace WebAPICoreTask_3.Models;

public partial class Rapper
{
    public int RapperId { get; set; }

    public string? RapperName { get; set; }

    public string? RapperImage { get; set; }

    public virtual ICollection<Track> Tracks { get; set; } = new List<Track>();
}
