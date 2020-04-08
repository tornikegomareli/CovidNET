using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CovidNET_lib.Http.Interfaces;

namespace CovidNET_lib.Http
{
    public class Requester : IRequester
    {
        private readonly string _relativeUrl;

        public Requester(string url)
        {
            _relativeUrl = url;
        }

        public async Task<string> CreateGetRequestAsync()
        {
            string page = _relativeUrl;
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(page))
                using (HttpContent content = response.Content)
                {
                    string result = await content.ReadAsStringAsync();


                    return result;
                }
            }
        }
    }
}
    