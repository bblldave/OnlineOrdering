using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public List<Service> Services { get; set; }
        public List<BusinessHour> BusinessHours { get; set; }
        public List<DeliveryZone> DeliveryZones { get; set; }
        public TableReservation TableReservation { get; set; }
        public OrderAhead OrderAhead { get; set; }
        public OrderForLater OrderForLater { get; set; }
    }
}
