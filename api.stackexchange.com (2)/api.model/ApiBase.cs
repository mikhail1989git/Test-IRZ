using api.model.Common;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace api.model
{
    public class ApiBase : IDisposable
    {
        private string baseUri;
        List<string> parameters;
        private HttpClient httpClient;

        public ApiBase(string baseUri)
        {
            this.baseUri = baseUri;
            parameters=new List<string>();
            httpClient = new HttpClient();
        }


        public async Task<string> SendAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, baseUri);//вытащить из листа параметры в стринг

            var response = await httpClient.SendAsync(request).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            

            return DecompressGZIP.Decompress(await response.Content.ReadAsStreamAsync().ConfigureAwait(false));
        }

        public void AddParameter(string field,string value) { 
            if(parameters.Count()==0)
                parameters.Add("#");
            else
                parameters.Add("&");

            parameters.Add(value);
        }

        public void AddParameter(string field, DateTime value) {
            if (parameters.Count() == 0)
                parameters.Add("#");
            else
                parameters.Add("&");

            
            var x = DateTimeOffset.FromUnixTimeMilliseconds(value);

            parameters.Add(value);
        }

        public void Dispose()
        {
            httpClient.Dispose();
        }
    }
}
