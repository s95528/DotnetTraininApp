namespace DotnetApp.Entities;

public class Dish
{
    public int Id { get; set; }
    
    public string Name { get; set; }

    public string Descrition { get; set; }
    
    public decimal Price { get; set; }
    
    public int RestauantId { get; set; }
    
    public virtual Restauant Restauant { get; set; }
}