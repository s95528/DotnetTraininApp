using AutoMapper;
using DotnetApp.DTO;
using DotnetApp.Entities;
using DotnetApp.Models;

namespace DotnetApp;

public class RestaurantMappingProfile : Profile
{
    public RestaurantMappingProfile()
    {
        CreateMap<Restauant, RestauantDTO>().ForMember(m => m.City, c => c.MapFrom(s => s.Address.City))
            .ForMember(m => m.Street, c => c.MapFrom(s => s.Address.Street))
            .ForMember(m => m.PostalCode, c => c.MapFrom(s => s.Address.PostalCode));

        CreateMap<Dish, DishDTO>();

        CreateMap<CreateRestaurantDto, Restauant>()
            .ForMember(r => r.Address, 
                c => c.MapFrom(dto => new Address()
                { City = dto.City, PostalCode = dto.PostalCode, Street = dto.Street }));
        
    }
}