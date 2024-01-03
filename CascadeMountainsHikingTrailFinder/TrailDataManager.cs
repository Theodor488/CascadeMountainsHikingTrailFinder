using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CascadeMountainsHikingTrailFinder
{
    public class TrailDataManager
    {
        public async Task<List<Hike>> GetTrailsAsync(HttpRequestMessage request)
        {
            using (HttpClient client = new HttpClient()) 
            {
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                string jsonData = await response.Content.ReadAsStringAsync();

                // Assuming the JSON structure aligns with your data model
                var hikesDict = JsonConvert.DeserializeObject<Dictionary<string, Hike>>(jsonData);
                List<Hike> hikesList = hikesDict.Values.ToList();

                // Prints basic trail info
                foreach (var hike in hikesList)
                {
                    Console.WriteLine($"{hike.Name}: {hike.Activities.Hiking.Length} miles");
                }

                return hikesList;
            }
        }
    }
}
