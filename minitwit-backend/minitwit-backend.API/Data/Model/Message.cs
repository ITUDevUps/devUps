namespace minitwit_backend.Data.Model;

public partial class Message
{
    public int MessageId { get; set; }

    public int AuthorId { get; set; }

    public string Text { get; set; } = string.Empty;

    public int? PubDate { get; set; }

    public int? Flagged { get; set; } = 0;
}