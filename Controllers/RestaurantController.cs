using AutoMapper;
using DotnetApp.DTO;
using DotnetApp.Entities;
using DotnetApp.Models;
using DotnetApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotnetApp.Controllers;

[Route("api/restaurant")]
public class RestaurantController: ControllerBase
{
    private readonly IRestaurantService _restaurantService;

    public RestaurantController(IRestaurantService restaurantService)
    {
        _restaurantService = restaurantService;
    }

    [HttpPost]
    public ActionResult CreateRestaurant([FromBody] CreateRestaurantDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var id = _restaurantService.Create(dto);
        
        return Created($"/api/restaurant/{id}", null);
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<RestauantDTO>> GetAll()
    {
        var restaurantDtos = _restaurantService.GetAll();
        
        return Ok(restaurantDtos);
    }

    [HttpGet("{id}")]
    public ActionResult<RestauantDTO> Get([FromRoute] int id)
    {
        var restaurant = _restaurantService.GetById(id);
        
        if (restaurant is null)
        {
            return NotFound("Brak restauracji");
        }

        return Ok(restaurant);
    }
}