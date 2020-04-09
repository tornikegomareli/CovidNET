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

        [Test]
        public void GetCountryTimeSeriesByName_throwsException_if_country_not_found()
        {
            string countryName = "nothing";


            Assert.Throws<CountryNotFoundException>(() =>
            {
                var result = _covidClient.GetCountryTimeSeriesByName(countryName);
            });
        }

        [Test]
        public void GetCountryTimeSeries_throwsException_if_dates_are_incorrect()
        {
            string countryName = "Georgia";
            var dateTimeFrom = new DateTime(2020, 4, 3);
            var dateTimeTo = new DateTime(2020, 3, 3);

            Assert.Throws<IncorrectDateTimesException>(() =>
            {
                var result = _covidClient.GetCountryTimeSeries(countryName, dateTimeFrom, dateTimeTo);
            });
        }

        [Test]
        public void GetCountryTimeSeries_throwsException_if_dates_are_correct_butCountryNot()
        {
            string countryName = "noone";
            var dateTimeFrom = new DateTime(2020, 3, 3);
            var dateTimeTo = new DateTime(2020, 4, 3);

            Assert.Throws<CountryNotFoundException>(() =>
            {
                var result = _covidClient.GetCountryTimeSeries(countryName, dateTimeFrom, dateTimeTo);
            });
        }
    }
}