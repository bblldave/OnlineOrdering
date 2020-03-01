using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class OrderForLater
    {
        public int Id { get; set; }
        public int PickupMinAdvanceMinutes { get; set; }
        public int PickupMaxAdvaceDays { get; set; }
        public int DeliveryMinAdvanceMinutes { get; set; }
        public int DeliveryMaxAdvanceDays { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
