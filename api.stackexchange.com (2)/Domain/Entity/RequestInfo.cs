using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class RequestInfo
    {
        public int Id { get; set; }
        public int CreationDate { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Answered { get; set; }
        public string Link { get; set; }
    }
}
