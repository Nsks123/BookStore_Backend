using Repository_BookStore_Layer.BookStoreContext;
using Repository_BookStore_Layer.BookStoreEntity;
using Repository_BookStore_Layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository_BookStore_Layer.Services
{
    public class WishListRepository :IWishListRepository
    {
        private readonly UserContext context;
        public WishListRepository(UserContext context)
        {
            this.context = context;
        }
        public WishListEntity AddToWishList(int id,int bookid)
        {
            var wishlist=context.WishListTable.SingleOrDefault(o=>o.UserId == id && o.BookId==bookid);
            if(wishlist == null)
            {
                wishlist = new WishListEntity();
                wishlist.UserId = id;
                wishlist.BookId = bookid;
                context.WishListTable.Add(wishlist);
                context.SaveChanges();
                return wishlist;

            }
            else
            {
                throw new Exception("The Book is Already in Wishlist");
            }
        }
        public List<WishListEntity> GetAllWishlist(int id)
        {
            return context.WishListTable.Where(o => o.UserId == id).ToList();
        }
        public WishListEntity DeleteWishList(int id, int wishlistid)
        {
            WishListEntity wishlistEntity = context.WishListTable.SingleOrDefault(o => o.UserId == id && o.WishListId == wishlistid);
            if (wishlistEntity != null)
            {
                context.WishListTable.Remove(wishlistEntity);
                context.SaveChanges();
                return wishlistEntity;
            }
            else
            {
                throw new Exception("WishListId is already empty");
            }

        }
    }
}
