using EventManagement.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManagement.DTOs
{
    public class EventDTO
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Location { get; set; }
        public int UserId { get; set; }
        [Required]
        public string EventDate { get; set; }
       

        public virtual User User { get; set; }
    }
}