using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CovidNET_lib.Extensions;
using CovidNET_lib.Http;
using CovidNET_lib.Models;
using CovidNET_lib.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CovidNET_lib
{
    internal class CovidDataManager
    {
        private string _jsonSource;

        internal void SetSource(string json)
        {
            _jsonSource = json;
		}


        internal string GetWholeCountryInfoJsonContentByName(string countryName)
        {
            var specificElements = FindElementFromkey(countryName);

            return specificElements;
		}


        private string FindElementFromkey(string key)
        {
            var cobj = (JObject)JsonConvert.DeserializeObject(_jsonSource);

            var element = cobj[key];

            return element.ToString();
        }

        internal async Task<string> GetGlobalInfoByDateJsonContentAsync(DateTime date)
        {
            var dateStr = date
                .Date
                .ToString(CultureInfo.InvariantCulture);

            var url = UrlManager.GlobalInfoByDate(dateStr);
            
            var request = new Requester(url);
            var content = await request.CreateGetRequestAsync();

            return content;
        }

        internal async Task<string> GetLatestGlobalInfoJsonContentAsync()
        {
            var url = UrlManager.GlobalInfoUrl;
            
            var request = new Requester(url);
            var content = await request.CreateGetRequestAsync();

            return content;
        }

        internal IEnumerable<CountryState> CountryTimeSeriesCollection(string country, DateTime from, DateTime to)
        {
            var wholeCountryContent = FindElementFromkey(country);

            var countryStates = wholeCountryContent.ToCountryState();

            foreach (var state in countryStates)
            {
                state.SpecificDateTime = Converters.StringToDateTime(state.Date);
            }

            var fromDate = from.Date;
            var toDate = to.Date;

            var indexOfFromDate = countryStates.IndexOf(countryStates.FirstOrDefault(o => o.SpecificDateTime.Date == fromDate));
            var indexOfToDate = countryStates.IndexOf(countryStates.FirstOrDefault(o => o.SpecificDateTime == toDate));

            return countryStates.Skip(indexOfFromDate).Take(indexOfToDate - indexOfFromDate);
        }
    }
}
