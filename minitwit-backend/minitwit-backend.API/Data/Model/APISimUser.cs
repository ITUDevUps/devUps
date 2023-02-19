using System.Text.Json.Serialization;

namespace minitwit_backend.Data.Model
{
    public class ApiSimUser
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}