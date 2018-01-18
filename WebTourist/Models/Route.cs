using System;
using System.Collections.Generic;

namespace WebTourist.Models
{
    public partial class Route
    {
        public Route()
        {
            RouteAttraction = new HashSet<RouteAttraction>();
        }

        public int Id { get; set; }
        public string Coordinates { get; set; }
        public string CoordinatesStartingPointsRoute { get; set; }

        public ICollection<RouteAttraction> RouteAttraction { get; set; }
    }
}
