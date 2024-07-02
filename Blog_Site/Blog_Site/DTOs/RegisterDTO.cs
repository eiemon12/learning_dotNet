using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog_Site.DTOs
{
    public class RegisterDTO
    {
        public int UId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int Phone { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Dob { get; set; }
        [Required]
        public string Gender { get; set; }

        public string UserType { get; set; }
    }
}