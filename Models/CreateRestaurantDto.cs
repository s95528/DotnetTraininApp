using System.ComponentModel.DataAnnotations;

namespace DotnetApp.Models;

public class CreateRestaurantDto
{
    [Required]
    [MaxLength(25)]
    public string Name { get; set; }

    public string Descrition { get; set; }

    public string Categoy { get; set; }

    public bool HasDelivery { get; set; }

    public string ContactNumber { get; set; }

    public string ContactEmail { get; set; }

    [Required]
    [MaxLength(50)]

    public string City { get; set; }
    
    [Required]
    [MaxLength(25)]
    public string Street { get; set; }

    public string PostalCode { get; set; }

}