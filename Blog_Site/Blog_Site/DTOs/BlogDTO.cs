using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog_Site.DTOs
{
    public class BlogDTO
    {
        public int BId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public System.DateTime Time { get; set; }
        public int UId { get; set; }
    }
}