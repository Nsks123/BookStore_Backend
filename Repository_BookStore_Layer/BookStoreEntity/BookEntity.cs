using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository_BookStore_Layer.BookStoreEntity
{
    public class BookEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        public string BookName {  get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string BookImage { get; set; }
        public float Price {  get; set; }
        public float DiscountPrice { get; set; }
        public int Quantity {  get; set; }
        public float Rating {  get; set; }
        public  DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set;}


    }
}
