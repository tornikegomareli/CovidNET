using System;
using System.Collections.Generic;
using System.Linq;
using CovidNET_lib.Models;
using CovidNET_lib.Models.Interfaces;

namespace CovidNET_lib.Utilities
{
    internal static class Converters
    {
        internal static IEnumerable<ICountryState> ConvertStringToDateTimes(IList<ICountryState> dataSource)
        {
            var copiedCollection = dataSource;
            foreach(var source in copiedCollection)
            {
                source.SpecificDateTime = StringToDateTime(source.Date);
			}

            return copiedCollection;
		}


        internal static DateTime StringToDateTime(string datestr)
        {
            return (DateTime)Convert.ChangeType(datestr, typeof(DateTime));
        }
    }
}
