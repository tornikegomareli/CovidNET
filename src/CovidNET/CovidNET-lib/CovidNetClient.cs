using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using CovidNET_lib.Extensions;
using CovidNET_lib.Http;
using CovidNET_lib.Models;
using CovidNET_lib.Models.Interfaces;
using CovidNET_lib.Utilities;

namespace CovidNET_lib
{
    public class CovidNetClient
    {
        private CovidDataManager _covidManager;

        public async Task InitCovidDataAsync()
		{
            var request = new Requester(Constants.PomberUrl);

            var content = await request.CreateGetRequestAsync();

            _covidManager = new CovidDataManager();

            _covidManager.SetSource(content);
		}

        public IEnumerable<ICountryState> GetCountryStatisticsByName(string countryName)
        {
           var source = _covidManager.GetCountryDataByName(countryName);

           var collection = source.ToCountryState();

           return collection;
        }

        public async Task<GlobalInfo> GetGlobalInfoByDateAsync(DateTime date)
        {
            var content = await _covidManager.GetGlobalInfoByDateJsonContentAsync(date);
            var globalInfo = content.ToGlobalInfoByDate();

            return new GlobalInfo()
            {
               Date = globalInfo.Date.UtcDateTime,
               Confirmed = globalInfo.Result.Confirmed,
               Deaths = globalInfo.Result.Deaths,
               Recovered = globalInfo.Result.Recovered
            };
        }

        public async Task<GlobalInfo> GetLatestGlobalInfo()
        {
            var content = await _c
        }
    }
}
