using System;
using System.Collections.Generic;

namespace minitwit_backend.Data;

public partial class User
{
    public long UserId { get; set; }

    public byte[] Username { get; set; } = null!;

    public byte[] Email { get; set; } = null!;

    public byte[] PwHash { get; set; } = null!;
}
