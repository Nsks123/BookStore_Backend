using Repository_BookStore_Layer.BookStoreEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository_BookStore_Layer.Interfaces
{
    public interface ICartRepository
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
