using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class DeliveryZone
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "decimal(12,2)")]
        public decimal MinAmount { get; set; }
        [Column(TypeName = "decimal(12,2)")]
        public decimal DeliveryFee { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
