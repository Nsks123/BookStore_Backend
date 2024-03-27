using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository_BookStore_Layer.BookStoreEntity
{
    public class UserEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Emailid { get; set; }
        public string Password { get; set; }
        [Phone]
        [Display(Name = "MobileNumber")]
        public string MobileNumber {  get; set; }
        public string Role {  get; set; }
    }
}
