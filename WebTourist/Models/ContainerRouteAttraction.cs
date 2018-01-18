using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTourist.Models
{
    public class ContainerRouteAttraction
    {
        public ContainerRouteAttraction()
        {

            attractions = new List<attraction>();
        }

        public int IdR { get; set; }
        public List<attraction> attractions { get; set; }
        public string CoordinatesRoute { get; set; }
        public string CoordinatesPointsStart { get; set; }
    }
    public struct attraction
    {
        public string Name;
        public string Description;
        public string CoordinateAt;

        public attraction(string n, string d, string c)
        {
            Name = n;
            Description = d;
            CoordinateAt = c;
        }

    }
}
