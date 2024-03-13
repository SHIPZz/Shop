using System.ComponentModel.DataAnnotations;

namespace Shop.Models;

public class UserViewModel
{
    [Required] public string Username { get; set; } = "";

    [Required] public string Password { get; set; } = "";
    
    [Required]
    public DateTime Birthday { get; set; } = DateTime.Now;
}