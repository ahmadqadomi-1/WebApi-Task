using System;
using System.Collections.Generic;

namespace WebAPICoreTask_3.Models;

public partial class PlayList
{
    public int PlayListId { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<PlayListTrack> PlayListTracks { get; set; } = new List<PlayListTrack>();

    public virtual User? User { get; set; }
}
