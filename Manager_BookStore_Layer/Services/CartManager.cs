using Manager_BookStore_Layer.Interfaces;
using Repository_BookStore_Layer.BookStoreEntity;
using Repository_BookStore_Layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager_BookStore_Layer.Services
{
    public class CartManager :ICartManager
    {
        private readonly ICartRepository repository;
        public CartManager(ICartRepository repository)
        {
            this.repository = repository;
        }
        //Add  to Cart
        public CartEntity AddCart(int id, int bookid)
        {
            return repository.AddCart(id, bookid);
        }
        //Get all Cart
        public List<CartEntity> GetAll(int id)
        {
            return repository.GetAll(id);
        }
        //Update Cart

        public CartEntity UpdateCart(int userid, int bookid)
        {
            return repository.UpdateCart(userid, bookid);
        }
        //Remove from Cart

        public CartEntity Removecart(int UserId, int ProductId)
        {
            return repository.Removecart(UserId, ProductId);
        }
        //Delete Cart
        public CartEntity DeleteCart(int id, int cartid)
        {
            return repository.DeleteCart(id, cartid);
        }
        public List<CartEntity> OrderBook(int id)
        {
            return repository.OrderBook(id);
        }
    }
}
