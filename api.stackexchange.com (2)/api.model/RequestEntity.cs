using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.model
{
    public class RequestEntity
    {
        public string page;
        public string pageSize;
        public string fromDate;
        public string toDate;
        public string order;
        public string min;
        public string max;
        public string sort;
        public string tagged;
        public string notTagged;
        public string inTitle;
        public string site;

        public RequestEntity(string page, string pageSize, string fromDate, string toDate, string order, string min, string max, string sort, string tagged, string notTagged, string inTitle, string site)
        {
            this.page = page;
            this.pageSize = pageSize;
            this.fromDate = fromDate;
            this.toDate = toDate;
            this.order = order;
            this.min = min;
            this.max = max;
            this.sort = sort;
            this.tagged = tagged;
            this.notTagged = notTagged;
            this.inTitle = inTitle;
            this.site = site;
        }
    }
}
