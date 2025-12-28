using System;
using System.Collections.Generic;

namespace Sitem.Web.Models
{
    public class BlogPost
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
        public string ImageUrl { get; set; }
        public int ViewCount { get; set; }
    }
}
