using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SubClasses
{
    public class Item
    {
        public string[] tags;
        public Owner owner;
        public bool is_answered;
        public int view_count;
        public int answer_count;
        public int score;
        public int last_activity_date;
        public int creation_date;
        public int last_edit_date;
        public string question_id;
        public string content_license;
        public string link;
        public string title;
    }
}
