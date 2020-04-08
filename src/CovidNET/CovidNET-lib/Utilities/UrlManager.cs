namespace CovidNET_lib.Utilities
 {
     public static class UrlManager
     {
         internal static string GlobalInfoUrl => Constants.CovidApiUrl + "all";
         internal static string AllCountriesUrl => Constants.CovidApiUrl + "countries";
 
         internal static string SpecificCountryUrl(string country)
         {
             return AllCountriesUrl + "/" + country;
         }

         internal static string GlobalInfoByDate(string date)
         {
             return Constants.CovidApiInfoBaseUrl + "global/" + $"{date}";
         }
     }
 }