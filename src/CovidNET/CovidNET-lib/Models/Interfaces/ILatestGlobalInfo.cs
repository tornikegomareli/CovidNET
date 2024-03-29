using Newtonsoft.Json;

namespace CovidNET_lib.Models.Interfaces
{
    public interface ILatestGlobalInfo
    {
        [JsonProperty("cases")]
        long Cases { get; set; }

        [JsonProperty("deaths")]
        long Deaths { get; set; }

        [JsonProperty("recovered")]
        long Recovered { get; set; }
    }
}