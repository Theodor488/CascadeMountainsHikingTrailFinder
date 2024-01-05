using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CascadeMountainsHikingTrailFinder.UserActions;

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

        public static string GetLocation()
        {
            Console.WriteLine("____Cascade Mountains Hiking Trail Finder____\n");
            Console.WriteLine("Choose a location: 1.Northern Cascades, 2.Central Cascades, 3.Southern Cascades");
            string locationChoice = Console.ReadLine();
            string location = ChooseLocation(locationChoice);
            return location;
        }

        public static string ChooseMaxResults()
        {
            Console.WriteLine("Choose max results: ");
            string maxResultsChoice = Console.ReadLine();
            bool keepAsking = true;

            try
            {
                while (keepAsking)
                {
                    if (int.TryParse(maxResultsChoice, out int maxResults))
                    {
                        if (maxResults < 0)
                        {
                            Console.WriteLine($"{maxResults} is invalid. Choose a positive number.");
                        }
                        else
                        {
                            keepAsking = false;
                        }
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Input. Please enter a number.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("the number is too large.");
            }

            return maxResultsChoice;
        }

        public static string ChooseLength()
        {
            Console.WriteLine("Choose max length: ");
            string maxLengthChoice = Console.ReadLine();
            bool keepAsking = true;

            try
            {
                while (keepAsking)
                {
                    if (int.TryParse(maxLengthChoice, out int maxLength))
                    {
                        if (maxLength < 0)
                        {
                            Console.WriteLine($"{maxLength} is invalid. Choose a positive number.");
                        }
                        else
                        {
                            keepAsking = false;
                        }
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Input. Please enter a number.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("the number is too large.");
            }

            return maxLengthChoice;
        }

        public static string ChooseLocation(string locationChoice)
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

            return location.ToString();
        }
    }
}
