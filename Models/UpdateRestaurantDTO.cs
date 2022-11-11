using System.ComponentModel.DataAnnotations;

namespace DotnetApp.Models;

public class UpdateRestaurantDTO
{
    [Required]
    [MaxLength(25)]
    public string Name { get; set; }
    
    public string Descrition { get; set; }
    
    public bool HasDelivery { get; set; }

}