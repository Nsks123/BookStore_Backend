using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common_BookStore_Layer.RequestModel
{
    public class UserRegModel
    {
        [RegularExpression(@"^[A-Z][a-z]{2,9}(?:\s[A-Z][a-z]{2,10})$", ErrorMessage = "Invalid name format.")]
        public string FullName { get; set; }
        [Required(ErrorMessage ="Email_Id is Required")]
        [EmailAddress( ErrorMessage = "Invalid Email_Id address.")]
        public string Emailid { get; set; }
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+\[\]{}|;:'""<>,.?/~`]).{8,}$",
       ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one digit, one special character, and be at least 8 characters long.")]
        public string Password { get; set; }
        [RegularExpression(@"^[7-9][0-9]{9}$", ErrorMessage = "Mobile number should be 10 digits long.")]
        public string MobileNumber { get; set; }
    }
}
