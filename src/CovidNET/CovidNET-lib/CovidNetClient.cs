using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
           var source = _covidManager.GetWholeCountryInfoJsonContentByName(countryName);

           var collection = source.ToCountryState();

           return collection;
        }

        public async Task<CovidInfo> GetGlobalInfoByDateAsync(DateTime date)
        {
            var content = await _covidManager.GetGlobalInfoByDateJsonContentAsync(date);
            var globalInfo = content.ToGlobalInfoByDate();

            return new CovidInfo()
            {
               Date = globalInfo.Date.UtcDateTime,
               Confirmed = globalInfo.Result.Confirmed,
               Deaths = globalInfo.Result.Deaths,
               Recovered = globalInfo.Result.Recovered
            };
        }

        public async Task<CovidInfo> GetLatestGlobalInfoAsync()
        {
            var content = await _covidManager.GetLatestGlobalInfoJsonContentAsync();

            var globalInfo = content.ToGlobalInfo();

            return new CovidInfo()
            {
                Date = DateTime.Now.Date,
                Deaths =  globalInfo.Deaths,
                Recovered = globalInfo.Recovered,
                Confirmed = globalInfo.Cases
            };
        }

        public List<CountryState> GetCountryTimeSeries(string country, DateTime from, DateTime to)
        {
            return _covidManager.CountryTimeSeriesCollection(country, from, to)
                                .ToList();
        }

        public async Task<List<CovidCountryStats>> GetCurrentAllCovidCountryStatsAsync()
        {
            var content = await _covidManager.GetCovidCountryJsonContent();

            var globalCountriesInfo = content.ToAllCovidCountryStat();

            return globalCountriesInfo;
        }

        public async Task<CovidCountryStats> GetCurrentCovidInfoByCountry(string country)
        {
            var content = await _covidManager.GetCovidInfoContentByCountryName(country);

            var covidCountryStat = content.ToCovidCountryStat();

            return covidCountryStat;
        }


        public async Task<CovidInfo> GetCovidCountryInfoByDate(string countryName, DateTime dateTime)
        {
            var covidCountryElement = _covidManager.GetCovidCountryElementByDate(countryName, dateTime);

            return new CovidInfo()
            {
                Date =  covidCountryElement.SpecificDateTime,
                Confirmed = covidCountryElement.Confirmed,
                Deaths =  covidCountryElement.Deaths,
                Recovered = covidCountryElement.Recovered
            };
        }
    }
}
