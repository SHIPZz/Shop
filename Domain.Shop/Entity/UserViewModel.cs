using System.ComponentModel.DataAnnotations;

namespace Domain.Shop.Entity;

public class UserViewModel
{
    [Required] public string Username { get; set; } = "";
    [Required] public string Email { get; set; } = "";

    [Required] public string Password { get; set; } = "";
    
    [Required]
    public DateTime Birthday { get; set; } = DateTime.Now;
}