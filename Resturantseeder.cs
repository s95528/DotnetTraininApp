using DotnetApp.Entities;

namespace DotnetApp;

public class Resturantseeder
{
    private readonly RestaurantDbContext _dbContext;

    public Resturantseeder(RestaurantDbContext dbContext)
    { 
        _dbContext = dbContext;
    }

    public void Seed()
    {
        if (_dbContext.Database.CanConnect())
        {
            if (!_dbContext.Restauants.Any())
            {
                var restaurants = GetRestaurants();
                _dbContext.Restauants.AddRange(restaurants);
                _dbContext.SaveChanges();
            }
        }  
    }

    private IEnumerable<Restauant> GetRestaurants()
    {
        var restauratants = new List<Restauant>()
        {
            new Restauant()
            {
                Name = "KFC",
                Categoy = "Fast Food",
                Descrition = "Good Fast Food",
                ContactNumber = "123123123",
                ContactEmail = "KFC@ZIOMEK.PL",
                HasDelivry = true,
                Dishes = new List<Dish>()
                {
                    new Dish()
                    {
                        Name = "Chicken",
                        Price = 23.23M,
                        Descrition = "Nice Dish",
                    },
                    new Dish()
                    {
                        Name = "Trap",
                        Price = 20.00M,
                        Descrition = "Good soup"
                    }
                },
                Address = new Address()
                {
                    City = "Lublin",
                    Street = "Przekątna",
                    PostalCode = "23-321"
                }
            },
            new Restauant()
            {
                Name = "LM",
                Categoy = "FancyFood",
                Descrition = "Italian restaurant",
                ContactNumber = "432432123",
                ContactEmail = "LM@MEK.PL",
                HasDelivry = false,
                Dishes = new List<Dish>()
                {
                    new Dish()
                    {
                        Name = "Spagetti",
                        Price = 45.23M,
                        Descrition = "Nice Dish",
                    },
                    new Dish()
                    {
                        Name = "Pizza",
                        Price = 25.00M,
                        Descrition = "Nice very",
                    },
                    new Dish()
                    {
                    Name = "Chips",
                    Price = 10.50M,
                    Descrition = "Nice Dish",
                    }
                },
                Address = 
                    new Address()
                {
                    City = "Kraków",
                    Street = "Przeciery",
                    PostalCode = "43-434"
                }
            },
            new Restauant()
            {
                Name = "McDonald",
                Categoy = "Fast Food",
                Descrition = "Good Fast Food",
                ContactNumber = "123123123",
                ContactEmail = "KFC@ZIOMEK.PL",
                HasDelivry = true,
                Dishes = new List<Dish>()
                {
                    new Dish()
                    {
                        Name = "Chicken",
                        Price = 23.23M,
                        Descrition = "Nice Dish",
                    },
                    new Dish()
                    {
                        Name = "Trap",
                        Price = 20.00M,
                        Descrition = "Good soup"
                    }
                },
                Address = new Address()
                {
                    City = "Lublin",
                    Street = "Przekątna",
                    PostalCode = "23-321"
                }
            },
        };
        return restauratants;
    }
}