using System.Text.Json.Serialization;

namespace minitwit_backend.Data.Model
{
    public class ApiSimFollow 
    {
        public string? UserName { get; set; }
        public string? Follow { get; set; }
        public string? UnFollow { get; set; }
    }
}