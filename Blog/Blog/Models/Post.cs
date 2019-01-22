using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }
        public string Img_big { get; set; }
        public string Img_small { get; set; }
        public int Priority { get; set; }

        public ICollection<PostTag> PostTags { get; set; }
    }
}
