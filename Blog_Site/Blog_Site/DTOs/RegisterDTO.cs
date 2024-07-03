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

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone is required.")]
        //[Phone]
        public int Phone { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        //[MinLength(4, ErrorMessage = "Password must be at least 4 characters long.")]
        [RegularExpression(@"^(?=.*[@#$]).{4,}$", ErrorMessage = "Password must be at least 4 characters long & contain one special character (@, #, $).")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Date of birth is required.")]
        public string Dob { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }

        public string UserType { get; set; }
    }
}