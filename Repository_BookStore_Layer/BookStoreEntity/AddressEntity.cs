using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Repository_BookStore_Layer.BookStoreEntity
{
    public class AddressEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressId {  get; set; }
        public string FullName {  get; set; }
        public string MobileNumber {  get; set; }
        public string Address { get; set; }
        public string City { get; set; }   
        public string State {  get; set; }
        public string label {  get; set; }
        [ForeignKey("UsersId")]
        public int UserId { get; set; }
        [JsonIgnore]
        public virtual UserEntity UsersId { get; set; }

    }
}
