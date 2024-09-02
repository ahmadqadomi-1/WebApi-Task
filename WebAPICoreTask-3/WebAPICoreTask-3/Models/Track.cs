using System;
using System.Collections.Generic;

namespace WebAPICoreTask_3.Models;

public partial class Track
{
    public int TrackId { get; set; }

    public string? TrackName { get; set; }

    public string? Description { get; set; }

    public string? Duration { get; set; }

    public int? RapperId { get; set; }

    public string? TrackImage { get; set; }

    public virtual ICollection<PlayListTrack> PlayListTracks { get; set; } = new List<PlayListTrack>();

    public virtual Rapper? Rapper { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
