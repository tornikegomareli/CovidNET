using Newtonsoft.Json;

namespace CovidNET_lib.Models.Interfaces
{
    public interface ICovidCountryStats
    {
        [JsonProperty("country")]
         string Country { get; set; }

        [JsonProperty("cases")]
         long Cases { get; set; }

        [JsonProperty("todayCases")]
         long TodayCases { get; set; }

        [JsonProperty("deaths")]
         long Deaths { get; set; }

        [JsonProperty("todayDeaths")]
         long TodayDeaths { get; set; }

        [JsonProperty("recovered")]
         long Recovered { get; set; }

        [JsonProperty("active")]
         long Active { get; set; }

        [JsonProperty("critical")]
         long Critical { get; set; }

        [JsonProperty("casesPerOneMillion")]
         long CasesPerOneMillion { get; set; }

        [JsonProperty("deathsPerOneMillion")]
         long DeathsPerOneMillion { get; set; }

        [JsonProperty("totalTests")]
         long TotalTests { get; set; }

        [JsonProperty("testsPerOneMillion")]
         long TestsPerOneMillion { get; set; }
    }
}