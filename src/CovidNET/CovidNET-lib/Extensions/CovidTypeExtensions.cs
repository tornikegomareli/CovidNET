using System;
using System.Collections.Generic;
using CovidNET_lib.Models;
using CovidNET_lib.Models.Interfaces;
using Newtonsoft.Json;

namespace CovidNET_lib.Extensions
{
    internal static class CovidTypeExtensions
    {
        internal static List<CountryState> ToCountryState(this string json)
        {
            return JsonConvert.DeserializeObject<List<CountryState>>(json);
		}

        internal static string ToJson(List<CountryState> collection)
        {
            return JsonConvert.SerializeObject(collection);
		}
    }
}
