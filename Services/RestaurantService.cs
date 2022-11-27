using AutoMapper;
using DotnetApp.DTO;
using DotnetApp.Entities;
using DotnetApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetApp.Services;

public interface IRestaurantService
{
    RestauantDTO GetById(int id);
    IEnumerable<RestauantDTO> GetAll();
    int Create(CreateRestaurantDto dto);
    public bool Delete(int id);
    bool Update(int id, UpdateRestaurantDTO dto);
}

public class RestaurantService : IRestaurantService
{
    private readonly RestaurantDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger<RestaurantService> _logger;

    public RestaurantService(RestaurantDbContext dbContext, IMapper mapper, ILogger<RestaurantService> logger)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _logger = logger;
    }
    
    public RestauantDTO GetById(int id)
    {
        var restaurant = _dbContext.Restauants
            .Include(r => r.Address)
            .Include(r => r.Dishes)
            .FirstOrDefault(r => r.Id == id);
        
        if (restaurant is null)
        {
            return null;
        }

        var result = _mapper.Map<RestauantDTO>(restaurant);

        return result;
    }


    public IEnumerable<RestauantDTO> GetAll()
    {
        var restaurants = _dbContext.Restauants.
            Include(r => r.Address)
            .Include(r => r.Dishes)
            .ToList();

        var resturantDtos = _mapper.Map<List<RestauantDTO>>(restaurants);

        return resturantDtos;
    }

    public int Create(CreateRestaurantDto dto)
    {
        _logger.LogWarning($"Restaurant CREATE action invoked");
        var restaurant = _mapper.Map<Restauant>(dto);
        _dbContext.Restauants.Add(restaurant);
        _dbContext.SaveChanges();

        return restaurant.Id;
    }

    public bool Update(int id, UpdateRestaurantDTO dto)
    {
        var restaurant = _dbContext.Restauants
            .FirstOrDefault(r => r.Id == id);

        restaurant.Name = dto.Name;
        restaurant.Descrition = dto.Descrition;
        restaurant.HasDelivry = dto.HasDelivery;
        
        _dbContext.Restauants.Update(restaurant);
        _dbContext.SaveChanges();
        
        if (restaurant is null)
        {
            return false;
        }

        return true;
    }
    
    public bool Delete(int id)
    {
        _logger.LogWarning($"Restaurant with id: {id} DELETE action invoked");
        
        var restaurant = _dbContext.Restauants
            .FirstOrDefault(r => r.Id == id);
        
        if (restaurant is null)
        {
            return false;
        }

        _dbContext.Restauants.Remove(restaurant);
        _dbContext.SaveChanges();

        return true;
    }
    
}