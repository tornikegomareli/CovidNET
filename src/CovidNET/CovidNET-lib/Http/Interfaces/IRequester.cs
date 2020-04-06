using System.Threading.Tasks;
using System.Collections.Generic;
using System;
namespace CovidNET_lib.Http.Interfaces
{
    public interface IRequester
    {
            /// <summary>
            /// Create a get request and send it asynchronously to the server.
            /// </summary>
            /// <returns>The content of the response.</returns>
           Task<string> CreateGetRequestAsync();
    }
}
