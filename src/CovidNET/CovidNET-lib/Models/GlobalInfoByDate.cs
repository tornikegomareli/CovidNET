using System;
using CovidNET_lib.Models.Interfaces;
using Newtonsoft.Json;

namespace CovidNET_lib.Models
{
    public class GlobalInfoByDate : IGlobalInfoByDate
    {
         [JsonProperty("count")]
         public long Count { get; set; }
         [JsonProperty("date")]
         public DateTimeOffset Date { get; set; }
         [JsonProperty("result")]
         public IResult Result { get; set; }
     }
 
 
     public class GlobalResult : IResult
     {
         [JsonProperty("confirmed")]
         public long Confirmed { get; set; }
         [JsonProperty("deaths")]
         public long Deaths { get; set; }
         [JsonProperty("recovered")]
         public long Recovered { get; set; }
     }
 }