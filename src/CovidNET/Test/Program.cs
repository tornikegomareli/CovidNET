using System;
using System.Collections.Generic;
using CovidNET_lib.Http;
using Newtonsoft.Json;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var requester = new Requester("https://pomber.github.io/covid19/timeseries.json");

            var sr = requester.CreateGetRequestAsync().Result;

            var data = JsonConvert.DeserializeObject<List<Country>>(sr);
        }
    }
}

public partial class Country
{
    public string name { get; set; }
    public List<Welcome> stats { get; set; }
}

public partial class Welcome
{
    [JsonProperty("date")]
    public string Date { get; set; }

    [JsonProperty("confirmed")]
    public long Confirmed { get; set; }

    [JsonProperty("deaths")]
    public long Deaths { get; set; }

    [JsonProperty("recovered")]
    public long Recovered { get; set; }
}