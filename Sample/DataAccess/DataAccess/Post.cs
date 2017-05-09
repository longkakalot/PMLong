using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Post
    {
        public int PostID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime? Publish { get; set; }
        public Post() { }

    }
}
