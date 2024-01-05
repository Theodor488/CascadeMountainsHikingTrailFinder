using System.Net.Http.Headers;
using System.Text.Json;
using CascadeMountainsHikingTrailFinder;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;

public class Program
{
    public static async Task Main(string[] args)
    {
        // Get apiKey/apiHost and settings from appsettings.json
        var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        IConfigurationRoot configuration = builder.Build();

        // Get Coords
        string zone = UserActions.GetLocation();
        string lat = configuration[$"ZoneCoords:{zone}:Latitude"];
        string lon = configuration[$"ZoneCoords:{zone}:Longitude"];
        string mapRadius = configuration["TrailSearchSettings:MapRadius"];
        string resultLimit = configuration["TrailSearchSettings:ResultLimit"];

        // Get maxLength
        int maxTrailLength = int.Parse(UserActions.ChooseLength());

        // Get maxResults
        int maxResults = int.Parse(UserActions.ChooseMaxResults());

        //Get apiKey/apiHost
        var apiKey = configuration["RapidAPI:Key"];
        var apiHost = configuration["RapidAPI:Host"];
        string requestUriString = $"https://trailapi-trailapi.p.rapidapi.com/activity/?lat={lat}&limit={resultLimit}&lon={lon}&radius={mapRadius}&q-activities_activity_type_name_eq=hiking";

        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(requestUriString),
            Headers =
                {
                    { "X-RapidAPI-Key", apiKey },
                    { "X-RapidAPI-Host", apiHost },
                },
        };

        TrailDataManager trailDataManager = new TrailDataManager();
        List<Hike> trailList = await trailDataManager.GetTrailsAsync(request, maxTrailLength, maxResults); 
    }
}
