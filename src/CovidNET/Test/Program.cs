using System;
using System.Collections.Generic;
using CovidNET_lib.Http;
using Newtonsoft.Json;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var requester = new Requester("https://pomber.github.io/covid19/timeseries.json");

            var sr = requester.CreateGetRequestAsync().Result;

        }
    }
}
