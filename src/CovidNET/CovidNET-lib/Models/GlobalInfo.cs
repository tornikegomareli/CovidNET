using System;
using CovidNET_lib.Models.Interfaces;

namespace CovidNET_lib.Models
{
    public class GlobalInfo
    {
        public DateTime Date { get; set; }
        public long Confirmed { get; set; }
        public long Deaths { get; set; }
        public long Recovered { get; set; }
    }
}