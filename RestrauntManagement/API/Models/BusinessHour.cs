using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class BusinessHour
    {
        public int Id { get; set; }
        public int Day { get; set; }
        public string OpenTime { get; set; }
        public string CloseTime { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
