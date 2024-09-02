using System;
using System.Collections.Generic;

namespace WebAPICoreTask_3.Models;

public partial class PlayListTrack
{
    public int PlayListTracksId { get; set; }

    public int? PlayListId { get; set; }

    public int? TrackId { get; set; }

    public int Quantity { get; set; }

    public virtual PlayList? PlayList { get; set; }

    public virtual Track? Track { get; set; }
}
