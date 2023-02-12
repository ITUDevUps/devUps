using System;
using System.Collections.Generic;

namespace minitwit_backend.Data;

public partial class Message
{
    public int MessageId { get; set; }

    public int AuthorId { get; set; }

    public String Text { get; set; } = String.Empty;

    public int? PubDate { get; set; }

    public int? Flagged { get; set; }
}
