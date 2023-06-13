using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal class ResponseEntity
    {
        public string[] tags;
        public Owner owner;
        public string is_answered;
        public string view_count;
        public string answer_count;
        public string score;
        public string last_activity_date;
        public string creation_date;
        public string question_id;
        public string content_license;
        public string link;
        public string title;
    }
}
