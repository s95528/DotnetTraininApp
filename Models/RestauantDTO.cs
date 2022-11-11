namespace DotnetApp.DTO;

public class RestauantDTO
{
    public int Id { get; set; }
    
    public string Name { get; set; }

    public string Descrition { get; set; }

    public string Categoy { get; set; }

    public bool HasDelivry { get; set; }
    
    public string City { get; set; }

    public string Street { get; set; }

    public string PostalCode { get; set; }
    
    public List<DishDTO> Dishes { get; set; }

}