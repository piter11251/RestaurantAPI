using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Entities;
using RestaurantAPI.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantAPI.Controllers
{
    [Route("api/restaurant")]
    public class RestaurantController : ControllerBase
    {
        private readonly RestaurantDbContext _dbContext;
        private readonly IMapper _mapper;
        public RestaurantController(RestaurantDbContext restaurantDbContext, IMapper mapper)
        {
            _dbContext = restaurantDbContext;
            _mapper = mapper;
        }
        [HttpPost]
        public ActionResult CreateRestaurant([FromBody] CreateRestaurantDTO dto)
        {
            var restaurant = _mapper.Map<Restaurant>(dto);
            _dbContext.Restaurants.Add(restaurant);
            _dbContext.SaveChanges();
            return Created($"/api/restaurant/{restaurant.Id}", null);
        }
        [HttpGet]
        public ActionResult<IEnumerable<RestaurantDTO>> GetAll()
        {
            var restaurants = _dbContext.Restaurants.Include(r => r.Address).Include(r => r.Dishes).ToList();
            var restaurantsDTO = _mapper.Map<List<RestaurantDTO>>(restaurants);
            return Ok(restaurantsDTO);
        }
        [HttpGet("{id}")]
        public ActionResult<RestaurantDTO> Get([FromRoute]int id)
        {
            var restaurant = _dbContext.Restaurants.Include(r => r.Address).Include(r => r.Dishes).FirstOrDefault(r => r.Id == id);
            if(restaurant is null)
            {
                return NotFound();
            }
            var restaurantDTO = _mapper.Map<RestaurantDTO>(restaurant);
            return Ok(restaurantDTO);
        }
    }
}
