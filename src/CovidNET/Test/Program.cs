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

            var data = current.GetCountryStatisticsByName("Georgia");
        }
    }
}
