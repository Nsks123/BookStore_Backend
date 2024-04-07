using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Repository_BookStore_Layer.BookStoreContext;
using Repository_BookStore_Layer.BookStoreEntity;
using Repository_BookStore_Layer.Interfaces;
using Repository_BookStore_Layer.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Repository_BookStore_Layer.Services
{
    
    public class CartRepository :ICartRepository
    {
        private readonly UserContext context;
        public CartRepository(UserContext context)
        {
            this.context = context;
        }
        //Add  to Cart
        public CartEntity AddCart(int id,int bookid)
        {
            var checking=context.BookTable.SingleOrDefault(o=>o.BookId==bookid);
            if (checking.Quantity != 0)
            {

                CartEntity cart = context.CartTable.SingleOrDefault(o => o.UserId == id && o.BookId == bookid);

                if (cart == null)
                {
                    cart = new CartEntity();
                    cart.UserId = id;
                    cart.BookId = bookid;
                    cart.IsPurchased = false;
                    cart.CartQuantity = 1;
                    cart.TotalPrice=checking.DiscountPrice;
                    context.CartTable.Add(cart);
                    context.SaveChanges();
                    return cart;
                }
                else
                {
                    throw new Exception("Book is Already In Cart");

                }
            }
            else
            {
                throw new Exception("Book is out of Stock");
            }
        }
        public List<CartEntity> GetAll(int id)
        {
            return context.CartTable.Where(o=>o.UserId==id).ToList();
        }
        public CartEntity UpdateCart(int userid, int bookid)
        {
            var cart = context.CartTable.FirstOrDefault(x => x.UserId == userid && x.BookId == bookid);
            if (cart != null)
            {
                var book = context.BookTable.FirstOrDefault(x => x.BookId == bookid);
                if (book != null && book.Quantity > cart.CartQuantity)
                {
                    cart.CartQuantity += 1;
                    context.SaveChanges();
                    return cart;
                }
                else
                {
                    throw new Exception("Product out of stock");
                }
            }
            else
            {
                throw new Exception("product not added to cart");
            }
        }
        public CartEntity Removecart(int UserId, int ProductId)
        {
            var existingCart = context.CartTable.FirstOrDefault(o => o.UserId == UserId && o.BookId == ProductId);
            if (existingCart != null)
            {
                var book = context.BookTable.FirstOrDefault(o => o.BookId == ProductId);
                if (book != null && 1 != existingCart.CartQuantity)
                {
                    existingCart.CartQuantity -= 1;
                    context.SaveChanges();
                    return existingCart;
                }
                else
                {
                    context.CartTable.Remove(existingCart);
                    context.SaveChanges();
                    return null;
                }
            }
            else
            {
                throw new Exception("Product not added to Cart");
            }
        }
        public CartEntity DeleteCart(int id,int cartid)
        {
            CartEntity cartEntity = context.CartTable.SingleOrDefault(o => o.UserId == id && o.CartId==cartid);
            if(cartEntity != null)
            {
                context.CartTable.Remove(cartEntity);
                context.SaveChanges();
                return cartEntity;
            }
            else
            {
                throw new Exception("Cartid is already empty");
            }
            
        }
        public List<CartEntity> OrderBook(int id)
        {
            var cart = context.CartTable.Where(o=>o.UserId==id ).ToList();
            if(cart != null)
            {
               foreach(var item in cart)
               {
                    item.IsPurchased = true;
                    item.OrderDate = DateTime.Now;
                    BookEntity book = context.BookTable.SingleOrDefault(book => book.BookId == item.BookId);
                    if (book.Quantity - item.CartQuantity > 0)
                    {

                        book.Quantity -= item.CartQuantity;
                    }
                    else
                    {

                        throw new Exception("Stock is less");
                    }
               } 
               context.SaveChanges();
               return cart;

            }
            else
            {
                throw new Exception("Cart Is Null");
            }
        }

       

    }
}
