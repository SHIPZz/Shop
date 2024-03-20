namespace Shop.Models;

public class ShoppingCartModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    
    public int DeviceId { get; set; }
    
    public int DeviceCount { get; set; }
    
}