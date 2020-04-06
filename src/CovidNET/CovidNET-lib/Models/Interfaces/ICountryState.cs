using Newtonsoft.Json;

namespace CovidNET_lib.Models.Interfaces
{
    public interface ICountryState
    {
        [JsonProperty("date")]
        string Date { get; set; }
        long Confirmed { get; set; }
        long Deaths { get; set; }
        long Recovered { get; set; }
    }
}