using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CascadeMountainsHikingTrailFinder
{
    public class Hike
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public string Directions { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public Activities Activities { get; set; }
    }

    public class Hiking
    {
        public string Length { get; set; }
    }

    public class Activities
    {
        public Hiking Hiking { get; set; }
    }
}
