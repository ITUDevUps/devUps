using System;
using System.Collections.Generic;

namespace minitwit_backend.Data;

public partial class User
{
    public int UserId { get; set; }

    public String Username { get; set; } = null!;

    public String Email { get; set; } = null!;

    public String PwHash { get; set; } = null!;
}
