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
        IResult Result { get; set; }
    }

    public interface IResult
    {
        [JsonProperty("confirmed")]
        public long Confirmed { get; set; }

        [JsonProperty("deaths")]
        public long Deaths { get; set; }

        [JsonProperty("recovered")]
        public long Recovered { get; set; }
    }
}