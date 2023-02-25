using System.ComponentModel.DataAnnotations;

namespace minitwit_backend.Data.Model;



public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PwHash { get; set; } = null!;

    public ISet<User> Following { get; set; } = new HashSet<User>();
    public ISet<User> Followers { get;set; } = new HashSet<User>();
}
