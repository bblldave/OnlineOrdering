using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class DataRepository : IDataRepository
    {
        private readonly DataContext _context;
        public DataRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Restaurant> GetRestaurant(int id)
        {
            var restaurant = await _context.Restaurants.Include(r => r.Locations).FirstOrDefaultAsync(r => r.Id == id);
            return restaurant;
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurants()
        {
            var restaurants = await _context.Restaurants.Include(r => r.Locations).ToListAsync();
            return restaurants;
        }

        public async Task<Location> GetLocation(int id)
        {
            var location = await _context.Locations
                .Include(l => l.Services)
                .Include(l => l.BusinessHours)
                .Include(l => l.DeliveryZones)
                .Include(l => l.OrderAhead)
                .Include(l => l.OrderAhead)
                .Include(l => l.TableReservation).FirstOrDefaultAsync(l => l.Id == id);
            return location;

        }

        public async Task<IEnumerable<Location>> GetRestaurantLocations(int restaurantId)
        {
            var locations = await _context.Locations.Where(l => l.RestaurantId == restaurantId).ToListAsync();
            return locations;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void MapUpdate<T, V>(ref T entity, V DTO, params string[] propsToIgnore)
            where T : class
            where V : class
        {
            if (entity != null && DTO != null)
            {
                Type entityType = typeof(T);
                Type DtoType = typeof(V);
                if (typeof(T) == typeof(V))
                {
                    foreach (System.Reflection.PropertyInfo prop in entityType.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
                    {
                        object entityPropValue = entityType.GetProperty(prop.Name).GetValue(entity, null);
                        object DtoPropValue = DtoType.GetProperty(prop.Name).GetValue(DTO, null);
                        if (prop.PropertyType.IsClass && prop.PropertyType.Name != "String")
                        {
                            MapUpdate(ref entityPropValue, DtoPropValue);
                        }
                        if (entityPropValue != DtoPropValue)
                        {
                            if (!propsToIgnore.Contains(prop.Name))
                            {
                                entityType.GetProperty(prop.Name).SetValue(entity, DtoPropValue);
                            }
                            
                        }
                    }
                }
            }
        }
    }
}
