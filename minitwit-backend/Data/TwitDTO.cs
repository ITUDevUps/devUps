using System.Security.Policy;

namespace minitwit_backend.Data
{
    public class TwitDTO
    {
        public string UserName { get; set; }
        public string Message { get; set; }

        public int? Date { get; set; }
    }
}
