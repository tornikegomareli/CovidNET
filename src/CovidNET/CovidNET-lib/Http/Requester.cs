using System;
using System.IO;
using System.Net;
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
            var url = _relativeUrl;
            string responseContent;
            var request = (HttpWebRequest) WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            using (var response = (HttpWebResponse) request.GetResponse())
            {
                await using var stream = response.GetResponseStream();
                using var reader = new StreamReader(stream ?? throw new ArgumentNullException());
                responseContent = await reader.ReadToEndAsync();
            }

            return responseContent;
        }
    }
}
    