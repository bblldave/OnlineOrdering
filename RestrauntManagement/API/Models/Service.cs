using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Service
    {
        public int Id { get; set; }
        public bool Pickup { get; set; }
        public bool Delivery { get; set; }
        public bool TableRes { get; set; }
        public bool OrderAhead { get; set; }
        public bool OrderForLater { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
