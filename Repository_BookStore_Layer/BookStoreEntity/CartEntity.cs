using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Repository_BookStore_Layer.BookStoreEntity
{
    public class CartEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartId { get; set; }

        public int CartQuantity {  get; set; }
        public bool IsPurchased {  get; set; }
        public DateTime OrderDate { get; set; }
        public float TotalPrice {  get; set; }
        [ForeignKey("UsersId")]
        public int UserId { get; set; }
        [JsonIgnore]
        public virtual UserEntity UsersId { get; set; }
        [ForeignKey("BooksId")]
        public int BookId {  get; set; }
        [JsonIgnore]
        public virtual BookEntity BooksId { get; set;}

    }
}
