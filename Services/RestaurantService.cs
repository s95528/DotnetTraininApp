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
}

public class RestaurantService : IRestaurantService
{
    private readonly RestaurantDbContext _dbContext;
    private readonly IMapper _mapper;

    public RestaurantService(RestaurantDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
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
        var restaurant = _mapper.Map<Restauant>(dto);
        _dbContext.Restauants.Add(restaurant);
        _dbContext.SaveChanges();

        return restaurant.Id;
    }

    public bool Delete(int id)
    {
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