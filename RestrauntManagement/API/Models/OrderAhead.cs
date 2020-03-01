using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class OrderAhead
    {
        public int Id { get; set; }
        public int MaxAdvanceDays { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
