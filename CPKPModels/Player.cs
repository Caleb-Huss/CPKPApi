using System;
using System.Collections.Generic;

namespace CPKPModels;

public partial class Player
{
    public int Playerid { get; set; }

    public string? Email { get; set; }

    public string? Username { get; set; }

    public DateTime? Createdate { get; set; }

    public DateTime? Lastlogin { get; set; }

    public virtual Stat? Stat { get; set; }
}
