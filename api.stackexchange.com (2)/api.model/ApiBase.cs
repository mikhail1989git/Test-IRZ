using api.model.Common;
using System;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
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

        public void AddParameter(RequestEntity request)
        {
            if (int.TryParse(request.page, out int pageResult))
                this.AddParameter("page", request.page);

            if (int.TryParse(request.pageSize, out int pageSizeResult))
                this.AddParameter("pageSize", request.pageSize);

            if (DateTime.TryParse(request.fromDate, out DateTime fromDateResult))
                this.AddParameter("fromDate", fromDateResult);

            if (DateTime.TryParse(request.toDate, out DateTime toDateResult))
                this.AddParameter("toDate", toDateResult);

            if(!string.IsNullOrWhiteSpace(request.order))
                this.AddParameter("order", request.order);

            if (DateTime.TryParse(request.min, out DateTime minResult))
                this.AddParameter("min", minResult);

            if (DateTime.TryParse(request.max, out DateTime maxResult))
                this.AddParameter("max", maxResult);

            if(!string.IsNullOrWhiteSpace(request.sort))
            this.AddParameter("sort", request.sort);

            if (!string.IsNullOrWhiteSpace(request.tagged))
                this.AddParameter("tagged", request.tagged);

            if (!string.IsNullOrWhiteSpace(request.notTagged))
                this.AddParameter("notTagged", request.notTagged);

            if (!string.IsNullOrWhiteSpace(request.inTitle))
                this.AddParameter("inTitle", request.inTitle);

            if (!string.IsNullOrWhiteSpace(request.site))
                this.AddParameter("site", request.site);
        }

        public void Dispose()
        {
            httpClient.Dispose();
        }
    }
}
