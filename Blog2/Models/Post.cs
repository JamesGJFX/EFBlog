using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog2.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public string PostBody { get; set; }
        public DateTime PostDate { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
