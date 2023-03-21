namespace minitwit_backend.Data.Model
{
    public class TwitDTO
    {
        public string UserName { get; set; }
        public string Message { get; set; }

        public int? Date { get; set; }
        public DateTime? DateTime { get; set; }
    }
}