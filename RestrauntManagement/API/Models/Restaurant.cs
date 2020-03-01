using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public int UserAcctId { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public string Cuisine { get; set; }
        public List<Location> Locations { get; set; }
    }
}
