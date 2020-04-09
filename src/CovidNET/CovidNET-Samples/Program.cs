using System;
using System.Collections.Generic;
using CovidNET_lib;
using CovidNET_lib.Http;
using Newtonsoft.Json;

// WARNING!
// you should call every async method with await and asynchronously
// because we are in Main, I am calling them syncrhonously.
// Never do it in production..

namespace CovidNETSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            var covidClient = new CovidNetClient();
            covidClient.InitCovidDataAsync().Wait(); 

            // exception is happening
            try
            {
                var globalInfoByDate = covidClient.GetGlobalInfoByDateAsync(new DateTime(2020, 03, 03).Date).Result;

                var latestGlobalInfo = covidClient.GetLatestGlobalInfoAsync().Result;

                var timeSeries = covidClient.GetCountryTimeSeries("Georgia", new DateTime(2020, 02, 03), new DateTime(2020, 03, 04));

                var allCovidCountriesInfo = covidClient.GetCurrentAllCovidCountryStatsAsync().Result;

                var covidInfoOnSpecificCountry = covidClient.GetCurrentCovidInfoByCountryAsync("Georgia").Result;

                var covidCountryInfoByDate = covidClient.GetCovidCountryInfoByDateAsync("Georgia", new DateTime(2020, 03, 03)).Result;

                var countryTimeSeries = covidClient.GetCountryTimeSeriesByName("Georgia");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
			}
             
        }
    }
}
