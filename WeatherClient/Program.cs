using CsvHelper;
using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace Weather
{
    public class WeatherClient
    {
        public static async Task Main(string[] args)
        {
            if (args.Length > 0)
            {
                var cord = GetCoordinates(args[0]);

                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.open-meteo.com/v1/forecast?latitude={cord[0]}&longitude={cord[1]}&current_weather=true");
                try
                {
                    var response = await client.SendAsync(request);
                    response.EnsureSuccessStatusCode();
                    Console.WriteLine(await response.Content.ReadAsStringAsync());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Incorrect inputs. {ex.Message}");
                }
            }
            else
                Console.WriteLine("Invalid input. Please provide both Latitude and Longitude.");
        }

        public static List<decimal> GetCoordinates(string cityName)
        {
            var list = new List<decimal>();
            var currentDirectory = System.IO.Directory.GetCurrentDirectory();
            //Console.WriteLine(currentDirectory);
            string filePath = Path.GetFullPath(Path.Combine(currentDirectory, @"in.csv"));
            //Console.WriteLine(filePath);
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var record = new WeatherData();
                var records = csv.EnumerateRecords(record);
                foreach (var r in records)
                {
                    if (r.city == cityName)
                    {
                        list.Add(Convert.ToDecimal(r.lat));
                        list.Add(Convert.ToDecimal(r.lng));
                    }
                }
            }
            return list;
        }
    }

    public class WeatherData
    {
        public string city { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
    }
}
