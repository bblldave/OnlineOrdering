using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IDataRepository _repo;

        public RestaurantController(IDataRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetRestaurants()
        {
            var restaurants = await _repo.GetRestaurants();
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestaurant(int id)
        {
            var restaurant = await _repo.GetRestaurant(id);
            return Ok(restaurant);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRestaurant(int id, Restaurant restaurant)
        {
            //TODO: make sure user is the correct user. If not return unauthorized

            var restrauntFromRepo = await _repo.GetRestaurant(id);
            var propsToIgnore = new String[] { "Id" };
            _repo.MapUpdate(ref restrauntFromRepo, restaurant, propsToIgnore);
            if (await _repo.SaveAll())
            {
                return NoContent();
            }
            throw new Exception($"Updating Restaurant {id} failed on save");
        }

        [HttpPost]
        public async Task<IActionResult> AddRestaurant(Restaurant restaurant)
        {
            _repo.Add<Restaurant>(restaurant);
            if (await _repo.SaveAll())
            {
                return CreatedAtAction("GetRestaurant", new { id = restaurant.Id }, restaurant);
            }
            throw new Exception($"Adding New Restaurant failed on save");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            var restaurant = await _repo.GetRestaurant(id);
            _repo.Delete<Restaurant>(restaurant);
            if (await _repo.SaveAll())
            {
                return Ok(restaurant);
            }
            throw new Exception($"Deleting Restaurant {id} failed on save");
        }
    }
}
