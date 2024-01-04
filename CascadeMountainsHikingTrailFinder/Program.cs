using System.Net.Http.Headers;
using System.Text.Json;
using CascadeMountainsHikingTrailFinder;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;

public class Program
{
    public string Lat;
    public string Lon;

    public static async Task Main(string[] args)
    {
        // Get Coords
        string[] coords = UserActions.GetCoords();
        string lat = coords[0];
        string lon = coords[1];

        string radius = "50";
        string limit = "200";

        // Get apiKey and apiHost from appsettings.json
        var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        IConfigurationRoot configuration = builder.Build();

        var apiKey = configuration["RapidAPI:Key"];
        var apiHost = configuration["RapidAPI:Host"];
        string requestUriString = $"https://trailapi-trailapi.p.rapidapi.com/activity/?lat={lat}&limit={limit}&lon={lon}&radius={radius}&q-activities_activity_type_name_eq=hiking";


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
        List<Hike> trailList = await trailDataManager.GetTrailsAsync(request);

        
    }
}
