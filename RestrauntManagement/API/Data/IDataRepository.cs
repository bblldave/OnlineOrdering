using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public interface IDataRepository
    {

        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<Restaurant>> GetRestaurants();
        Task<Restaurant> GetRestaurant(int id);
        Task<Location> GetLocation(int id);
        Task<IEnumerable<Location>> GetRestaurantLocations(int restaurantId);

        public void MapUpdate<T, V>(ref T entity, V DTO, params String[] propsToIgnore) where T : class where V : class;
        
    }
}
