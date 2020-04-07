using System;
namespace CovidNET_lib.Exceptions
{
    public class StringIsNullOrEmptyException : Exception
    {
        public StringIsNullOrEmptyException() : base("String is nur or empty")
        {
        }
    }
}
