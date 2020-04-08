using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CovidNET_lib.Exceptions;
using CovidNET_lib.Extensions;
using CovidNET_lib.Http;
using CovidNET_lib.Models;
using CovidNET_lib.Models.Interfaces;
using CovidNET_lib.Utilities;

namespace CovidNET_lib
{
    /// <summary>
    /// A  CvoidClient which is responsible for all the API calls
    /// </summary>
    public class CovidNetClient
    {
        private CovidDataManager _covidManager;


        /// <summary>
        /// Initializes Covid client, which will sync the newest data from API's
        /// </summary>
        /// <exception cref="AggregateException">counryName</exception>
        public async Task InitCovidDataAsync()
		{
            var request = new Requester(Constants.PomberUrl);

            var content = await request.CreateGetRequestAsync();

            _covidManager = new CovidDataManager();

            _covidManager.SetSource(content);
		}

        /// <summary>
        /// Get specific countries time series, from 22 January.
        /// </summary>
        /// <param name="acountryName">The Country Name</param>
        /// <exception cref="CountryNotFoundException">counryName</exception>
        /// <exception cref="StringIsNullOrEmptyException">counryName</exception>
        public IEnumerable<CovidInfo> GetCountryTimeSeriesByName(string countryName)
        {
            if (string.IsNullOrEmpty(countryName))
            {
                throw new StringIsNullOrEmptyException();
            }
            
           var source = _covidManager.GetWholeCountryInfoJsonContentByName(countryName);

           var collection = source.ToCountryState();

           return collection.Select(o => new CovidInfo()
           {
               Date = o.SpecificDateTime,
               Deaths = o.Deaths,
               Confirmed = o.Confirmed,
               Recovered = o.Recovered,
           });
        }

        /// <summary>
        /// Get global covid info on specific Date
        /// </summary>
        /// <param name="DateTime">date</param>
        /// <exception cref="CovidDataNotFoundException"></exception>
        public async Task<CovidInfo> GetGlobalInfoByDateAsync(DateTime date)
        {
            if(date < new DateTime(2020, 1, 22))
            {
                throw new CovidDataNotFoundException();
			}

            var content = await _covidManager.GetGlobalInfoByDateJsonContentAsync(date);
            var globalInfo = content.ToGlobalInfoByDate();

            return new CovidInfo()
            {
               Date = (globalInfo.Date.UtcDateTime).Date,
               Confirmed = globalInfo.Result.Confirmed,
               Deaths = globalInfo.Result.Deaths,
               Recovered = globalInfo.Result.Recovered
            };
        }


        /// <summary>
        /// Get latest global covid info of deathrate, recovered and confirmed
        /// </summary>
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


        /// <summary>
        /// Get specific country Time series of covid info between range of Dates
        /// </summary>
        /// <param name="country">string</param>
        /// <param name="from">DateTime</param>
        /// <param name="to">DateTime</param>
        /// <exception cref="CovidDataNotFoundException"></exception>
        /// <exception cref="IncorrectDateTimesException"></exception>
        public IEnumerable<CovidInfo> GetCountryTimeSeries(string country, DateTime from, DateTime to)
        {
            if(from < to)
            {
                throw new IncorrectDateTimesException(); 
			}

            if (from < new DateTime(2020, 1, 22))
            {
                throw new CovidDataNotFoundException();
            }

            if(to > DateTime.Now)
            {
                throw new CovidDataNotFoundException();
            }

            var countryTimeSeries = _covidManager.CountryTimeSeriesCollection(country, from, to)
                                .ToList();

            return countryTimeSeries.Select(o => new CovidInfo()
            {
                Date = o.SpecificDateTime,
                Deaths = o.Deaths,
                Confirmed = o.Confirmed,
                Recovered = o.Recovered,
            });
        }


        /// <summary>
        /// All Covid countries statistics from first case till today.
        /// </summary>
        public async Task<IEnumerable<CovidCountryStats>> GetCurrentAllCovidCountryStatsAsync()
        {
            var content = await _covidManager.GetCovidCountryJsonContent();

            var globalCountriesInfo = content.ToAllCovidCountryStat();

            return globalCountriesInfo;
        }

        /// <summary>
        /// Specific country covid info, from first case till today
        /// </summary>
        /// <param name="country">string</param>
        public async Task<CovidCountryStats> GetCurrentCovidInfoByCountry(string country)
        {
            var content = await _covidManager.GetCovidInfoContentByCountryName(country);

            var covidCountryStat = content.ToCovidCountryStat();

            return covidCountryStat;
        }

        /// <summary>
        /// Get's specific country info by date
        /// </summary>
        /// <param name="country">string</param>
        /// <param name="dateTime">DateTime</param>
        /// <exception cref="CovidDataNotFoundException"></exception>
        /// <exception cref="IncorrectDateTimesException"></exception>
        public async Task<CovidInfo> GetCovidCountryInfoByDate(string countryName, DateTime dateTime)
        {
            if(dateTime > DateTime.Now)
            {
                throw new IncorrectDateTimesException();
			}

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
