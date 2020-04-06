using System.Threading.Tasks;
using System.Collections.Generic;
using System;
namespace CovidNET_lib.Http.Interfaces
{
    public interface IRequester
    {
           Task<string> CreateGetRequestAsync(string relativeUrl);
    }
}
