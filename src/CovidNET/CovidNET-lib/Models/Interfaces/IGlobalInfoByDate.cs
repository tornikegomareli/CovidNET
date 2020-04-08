using System;
using Newtonsoft.Json;

namespace CovidNET_lib.Models.Interfaces
{
    public interface IGlobalInfoByDate
    {
        [JsonProperty("count")]
        long Count { get; set; }

        [JsonProperty("date")]
        DateTimeOffset Date { get; set; }

        [JsonProperty("result")]
        GlobalResult Result { get; set; }
    }
}