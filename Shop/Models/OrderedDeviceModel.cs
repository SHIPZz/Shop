using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models;

public class OrderedDeviceModel
{
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int UserId { get; set; }
    
    public bool IsPurchased { get; set; }

    public string Name { get; set; }

    public string ImagePath { get; set; }

    public float Price { get; set; }

    public int Count { get; set; }
}