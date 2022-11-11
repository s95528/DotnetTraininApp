using System.Net.Sockets;

namespace DotnetApp.Entities;

public class Restauant
{
    public int Id { get; set; }
    
    public string Name { get; set; }

    public string Descrition { get; set; }

    public string Categoy { get; set; }

    public bool HasDelivry { get; set; }

    public string ContactNumber { get; set; }

    public string ContactEmail { get; set; }
    
    public int AddressId { get; set; }
    
    public virtual Address Address { get; set; }
    
    public virtual List<Dish> Dishes { get; set; }

}