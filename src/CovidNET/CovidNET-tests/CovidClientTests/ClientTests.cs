using System;
using System.Threading.Tasks;
using CovidNET_lib;
using CovidNET_lib.Exceptions;
using NUnit.Framework;

namespace CovidNET_tests.CovidClientTests
{
    public class ClientTests
    {
        CovidNetClient _covidClient;
        [SetUp]
        public async Task Setup()
        {
            _covidClient = new CovidNetClient();
            await _covidClient.InitCovidDataAsync();
        }

        [Test]
        public void GetCountryTimeSeries_throwsException_if_date_is_less_then_22January()
        {
            var dateTime = new DateTime(2020, 1, 3);


            Assert.Throws<AggregateException>(() => 
			{
                var result = _covidClient.GetGlobalInfoByDateAsync(dateTime).Result;
            });
        }

        [Test]
        public void GetCountryTimeSeriesByName_throwsException_if_string_is_null()
        {
            string countryName = null;


            Assert.Throws<StringIsNullOrEmptyException>(() =>
            {
                var result = _covidClient.GetCountryTimeSeriesByName(countryName);
            });
        }

        [Test]
        public void GetCountryTimeSeriesByName_throwsException_if_string_is_empty()
        {
            string countryName = string.Empty;


            Assert.Throws<StringIsNullOrEmptyException>(() =>
            {
                var result = _covidClient.GetCountryTimeSeriesByName(countryName);
            });
        }
    }
}