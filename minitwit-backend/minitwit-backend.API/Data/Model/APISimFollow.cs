using System.Text.Json.Serialization;

namespace minitwit_backend.Data.Model
{
    public class ApiSimFollow 
    {
        public string? Follow { get; set; }
        public string? Unfollow { get; set; }
    }
}