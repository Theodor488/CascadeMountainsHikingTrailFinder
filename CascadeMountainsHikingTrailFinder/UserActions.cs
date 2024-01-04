using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CascadeMountainsHikingTrailFinder
{
    public static class UserActions
    {
        public enum Locations
        {
            NorthernCascades,
            CentralCascades,
            SouthernCascades,
            Unknown
        }
        // test
        public static string[] GetCoords()
        {
            Console.WriteLine("____Cascade Mountains Hiking Trail Finder____\n");
            Console.WriteLine("Choose a location: 1.Northern Cascades, 2.Central Cascades, 3.Southern Cascades");
            string locationChoice = Console.ReadLine();

            string[] coords = ChooseLocation(locationChoice);
            return coords;
        }

        public static string[] ChooseLocation(string locationChoice)
        {
            Locations location = Locations.Unknown;
            bool askForLocation = true;

            while (askForLocation)
            {
                if (locationChoice == "1")
                {
                    location = Locations.NorthernCascades;
                    askForLocation = false;
                }
                else if (locationChoice == "2")
                {
                    location = Locations.CentralCascades;
                    askForLocation = false;
                }
                else if (locationChoice == "3")
                {
                    location = Locations.SouthernCascades;
                    askForLocation = false;
                }
                else
                {
                    Console.WriteLine("Unkown location. Choose 1 (North), 2 (Central) or 3 (South).");
                }
            }

            string[] coords = AssignCoords(location);

            return coords;
        }

        public static string[] AssignCoords(Locations location)
        {
            string[] coords = new string[2];

            if (location == Locations.NorthernCascades)
            {
                coords[0] = "48.73"; // lat
                coords[1] = "-121.11"; // lon
            }
            else if (location == Locations.CentralCascades)
            {
                coords[0] = "47.71"; // lat
                coords[1] = "-121.31"; // lon
            }
            else if (location == Locations.SouthernCascades) 
            {
                coords[0] = "46.22"; // lat
                coords[1] = "-121.62"; // lon 
            }
            else
            {
                coords[0] = "0"; // lat
                coords[1] = "0"; // lon 
            }

            return coords;
        }
    }
}
