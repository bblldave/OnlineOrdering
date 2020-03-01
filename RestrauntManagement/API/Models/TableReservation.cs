using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class TableReservation
    {
        public int Id { get; set; }
        public int MinPeople { get; set; }
        public int MaxPeople { get; set; }
        public int TableKeptMinutes { get; set; }
        public int MinAdvanceMinutes { get; set; }
        public int MaxAdvaceDays { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
