using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<DeliveryZone> DeliveryZones { get; set; }
        public DbSet<BusinessHour> BusinessHours { get; set; }
        public DbSet<TableReservation> TableReservations { get; set; }
        public DbSet<OrderAhead> OrderAheads { get; set; }
        public DbSet<OrderForLater> orderForLaters { get; set; }
    }
}
