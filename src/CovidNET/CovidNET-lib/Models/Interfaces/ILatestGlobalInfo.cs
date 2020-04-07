using Newtonsoft.Json;

namespace CovidNET_lib.Models.Interfaces
{
    public interface IGlobalInfo
    {
        [JsonProperty("cases")]
        long Cases { get; set; }

        [JsonProperty("deaths")]
        long Deaths { get; set; }

        [JsonProperty("recovered")]
        long Recovered { get; set; }
    }
}