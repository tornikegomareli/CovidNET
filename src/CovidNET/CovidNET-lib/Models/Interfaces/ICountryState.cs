using System;
using Newtonsoft.Json;

namespace CovidNET_lib.Models.Interfaces
{
    public interface IInformative
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
}