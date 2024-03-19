using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models;

public class OrderedDeviceModel
{
    [Required] [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }
    
    public int UserId { get; set; }
}