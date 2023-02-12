using System;
using System.Collections.Generic;

namespace minitwit_backend.Data;

public partial class Follower
{
    public int? WhoId { get; set; }

    public int? WhomId { get; set; }
}
