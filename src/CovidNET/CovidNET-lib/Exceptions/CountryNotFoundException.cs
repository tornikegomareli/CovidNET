using System;
namespace CovidNET_lib.Exceptions
{
    public class CountryNotFoundException : Exception
    {
        public CountryNotFoundException() : base("Country not found in the list")
        {
        }
    }
}
