using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Repository_BookStore_Layer.BookStoreEntity
{
    public class WishListEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WishListId { get; set; }
        [ForeignKey("UsersId")]
        public int UserId { get; set; }
        [JsonIgnore]
        public virtual UserEntity UsersId { get; set; }
        [ForeignKey("BooksId")]
        public int BookId { get; set; }
        [JsonIgnore]
        public virtual BookEntity BooksId { get; set; }
    }
}
