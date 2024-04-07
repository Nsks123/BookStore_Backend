using Repository_BookStore_Layer.BookStoreEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager_BookStore_Layer.Interfaces
{
   public interface ICartManager
    {
        //Add  to Cart
        public CartEntity AddCart(int id, int bookid);
        public List<CartEntity> GetAll(int id);
        public CartEntity UpdateCart(int userid, int bookid);
        public CartEntity Removecart(int UserId, int ProductId);
        public CartEntity DeleteCart(int id, int cartid);
        public List<CartEntity> OrderBook(int id);
    }
}
