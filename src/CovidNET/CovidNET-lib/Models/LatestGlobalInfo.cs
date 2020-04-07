using CovidNET_lib.Models.Interfaces;
using Newtonsoft.Json;

namespace CovidNET_lib.Models
{
    public class LatestGlobalInfo : ILatestGlobalInfo
    {
            [JsonProperty("cases")]
            public long Cases { get; set; }

            [JsonProperty("deaths")]
            public long Deaths { get; set; }

            [JsonProperty("recovered")]
            public long Recovered { get; set; }
    }
}