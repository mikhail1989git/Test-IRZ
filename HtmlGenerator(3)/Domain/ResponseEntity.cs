using Domain.SubClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ResponseEntity
    {
        public Item[] items;
        public bool has_more;
        public int quota_max;
        public int quota_remaining;
    }
}
