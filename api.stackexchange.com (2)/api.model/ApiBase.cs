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
        private HttpClient httpClient;
        private string parameters;
        public string Parameters { get => parameters; }

        public ApiBase(string baseUri)
        {
            this.baseUri = baseUri;
            parameters=string.Empty;
            httpClient = new HttpClient();
        }


        public async Task<string> SendAsync()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, baseUri + AllParametersToString());

                var response = await httpClient.SendAsync(request).ConfigureAwait(false);

                return DecompressGZIP.Decompress(await response.Content.ReadAsStreamAsync().ConfigureAwait(false));
            }

            catch (Exception ex)
            { 
                return ex.Message;
            }
        }

        public void AddParameter(string field,string value) {

            StringBuilder stringBuilder = new StringBuilder();

            if (parameters.Count() == 0)
                stringBuilder.Append("?");
            else
                stringBuilder.Append("&");

            stringBuilder.Append(field);
            stringBuilder.Append("=");
            stringBuilder.Append(value);

            parameters+=stringBuilder.ToString();
        }

        public void AddParameter(string field, DateTime value) {

            StringBuilder stringBuilder = new StringBuilder();
            DateTime StartDateFromUnix = new DateTime(1970, 1, 1);
            long date = (long)(value - StartDateFromUnix).TotalSeconds;

            if (parameters.Count() == 0)
                stringBuilder.Append("?");
            else
                stringBuilder.Append("&");

            stringBuilder.Append(field);
            stringBuilder.Append("=");
            stringBuilder.Append(date.ToString());

            parameters+=stringBuilder.ToString();
        }

        private string AllParametersToString()
        { 
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var x in parameters)
                stringBuilder.Append(x);

            return stringBuilder.ToString();
        }

        public void Dispose()
        {
            httpClient.Dispose();
        }
    }
}
