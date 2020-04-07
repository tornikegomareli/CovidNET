using System;
namespace CovidNET_lib.Exceptions
{
    public class IncorrectDateTimesException : Exception
    {
        public IncorrectDateTimesException() : base("Incorrect date times")
        {
        }
    }
}
