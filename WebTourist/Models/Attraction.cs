using System;
using System.Collections.Generic;

namespace WebTourist.Models
{
    public partial class Attraction
    {
        public Attraction()
        {
            RouteAttraction = new HashSet<RouteAttraction>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Coordinate { get; set; }

        public ICollection<RouteAttraction> RouteAttraction { get; set; }
    }
}
