using System;
using Newtonsoft.Json;

namespace CovidNET_lib.Models.Interfaces
{
    public interface ICountryState
    {
        [JsonProperty("date")]
        string Date { get; set; }

        [JsonProperty("confirmed")]
        long Confirmed { get; set; }

        [JsonProperty("deaths")]
        long Deaths { get; set; }

        [JsonProperty("recovered")]
        long Recovered { get; set; }

        DateTime SpecificDateTime { get; set; }
    }
}