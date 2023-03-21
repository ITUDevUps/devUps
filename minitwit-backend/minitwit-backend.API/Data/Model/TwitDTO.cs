namespace minitwit_backend.Data.Model
{
    public class TwitDto
    {
        public string UserName { get; set; }
        public string Message { get; set; }

        public int? Date { get; set; }
    }
}