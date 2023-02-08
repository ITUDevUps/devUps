using System;
using System.Collections.Generic;

namespace minitwit_backend.Data;

public partial class Follower
{
    public long? WhoId { get; set; }

    public long? WhomId { get; set; }
}
