using System;
namespace CovidNET_lib.Exceptions
{
    public class CovidDataNotFoundException : Exception
    {
        public CovidDataNotFoundException() : base("Covid data not found")
        {
        }
    }
}
