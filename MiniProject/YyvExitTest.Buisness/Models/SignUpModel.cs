﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace YYvMiniProject.Buisness.Models
{
    public class SignUpModel
    {
        [Required(ErrorMessage = "Enter your Full Name")]
        [Display(Name = "Full Name")]
        [StringLength(50)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Enter your Email")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Enter Valid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "Enter your Password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Enter your Password")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

    }
}
