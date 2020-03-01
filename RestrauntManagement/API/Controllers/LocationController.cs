using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IDataRepository _repo;

        public LocationController(IDataRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("[Action]/{restaurantId}")]
        public async Task<IActionResult> GetRestaurantLocations(int restaurantId)
        {
            var locations = await _repo.GetRestaurantLocations(restaurantId);
            return Ok(locations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocation(int id)
        {
            var location = await _repo.GetLocation(id);
            return Ok(location);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLocation(int id, Location location)
        {
            //TODO: make sure user is the correct user. If not return unauthorized

            var locationFromRepo = await _repo.GetLocation(id);
            var propsToIgnore = new String[] { "Id", "RestaurantId" };
            _repo.MapUpdate(ref locationFromRepo, location, propsToIgnore);
            if (await _repo.SaveAll())
            {
                return NoContent();
            }
            throw new Exception($"Updating Restaurant {id} failed on save");
        }

        [HttpPost]
        public async Task<IActionResult> AddLocation(Location location)
        {
            _repo.Add<Location>(location);
            if (await _repo.SaveAll())
            {
                return CreatedAtAction("GetLocation", new { id = location.Id }, location);
            }
            throw new Exception($"Adding new Location failed on save");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            var location = await _repo.GetLocation(id);
            _repo.Delete<Location>(location);
            if (await _repo.SaveAll())
            {
                return Ok(location);
            }
            throw new Exception($"Deleting location {id} failed on save");
        }

    }
}