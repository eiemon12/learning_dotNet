using BlogSite.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogSite.DTOs
{
    public class PostBlogDTO
    {
        public int BId { get; set; }
        public System.DateTime Time { get; set; }
        public int UId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
    }
}