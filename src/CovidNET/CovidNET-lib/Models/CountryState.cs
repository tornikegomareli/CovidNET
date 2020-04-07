using System;
using CovidNET_lib.Models.Interfaces;
using Newtonsoft.Json;

namespace CovidNET_lib.Models
{
    public class CountryState : ICountryState
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("confirmed")]
        public long Confirmed { get; set; }

        [JsonProperty("deaths")]
        public long Deaths { get; set; }

        [JsonProperty("recovered")]
        public long Recovered { get; set; }

        public DateTime SpecificDateTime { get; set; }
    }
}