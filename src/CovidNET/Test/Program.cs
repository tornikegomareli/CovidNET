﻿using System;
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

            // exception is happening
            try
            {
                var s = current.GetGlobalInfoByDateAsync(new DateTime(2020, 03, 03).Date).Result;
                var s1 = current.GetLatestGlobalInfoAsync().Result;
                var s2 = current.GetCountryTimeSeries("Georgia", new DateTime(2020, 02, 03), new DateTime(2020, 03, 04));
                var s3 = current.GetCurrentAllCovidCountryStatsAsync().Result;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
			}
            
        }
    }
}
