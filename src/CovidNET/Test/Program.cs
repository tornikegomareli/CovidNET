using System;
using System.Collections.Generic;
using CovidNET_lib;
using CovidNET_lib.Http;
using Newtonsoft.Json;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var current = new CovidNetClient();
            current.InitCovidDataAsync().Wait();

            current.GetCountryTimeSeriesByName("Georgia");
            var februa = new DateTime(2019, 04, 6);
            var s = current.GetGlobalInfoByDateAsync(februa).Result;
        }
    }
}
