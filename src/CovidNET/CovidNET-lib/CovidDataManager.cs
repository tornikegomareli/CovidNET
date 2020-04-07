using System;
using System.Globalization;
using System.Threading.Tasks;
using CovidNET_lib.Http;
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


        internal string GetCountryDataByName(string countryName)
        {
            var specificElements = FindElementFromkey(countryName);

            return specificElements;
		}


        internal string FindElementFromkey(string key)
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
    }
}
