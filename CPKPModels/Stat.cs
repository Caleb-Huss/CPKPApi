using System;
using System.Collections.Generic;

namespace CPKPModels;

public partial class Stat
{
    public int Playerid { get; set; }

    public int? Totalguesses { get; set; }

    public int? Correctguesses { get; set; }

    public int? Higheststreak { get; set; }

    public int? Shiniesseen { get; set; }

    public virtual Player Player { get; set; } = null!;
}
