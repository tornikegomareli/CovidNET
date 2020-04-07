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

        internal static LatestGlobalInfo ToGlobalInfo(this string json)
        {
            return JsonConvert.DeserializeObject<LatestGlobalInfo>(json);
        }

        internal static GlobalInfoByDate ToGlobalInfoByDate(this string json)
        {
            return JsonConvert.DeserializeObject<GlobalInfoByDate>(json);
        }

        internal static string ToJson(List<CountryState> collection)
        {
            return JsonConvert.SerializeObject(collection);
		}

        internal static List<CovidCountryStats> ToAllCovidCountryStat(this string json)
        {
            return JsonConvert.DeserializeObject<List<CovidCountryStats>>(json);
        }

        internal static CovidCountryStats ToCovidCountryStat(this string json)
        {
            return JsonConvert.DeserializeObject<CovidCountryStats>(json);
        }
    }
}
