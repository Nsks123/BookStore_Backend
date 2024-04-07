using Repository_BookStore_Layer.BookStoreEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager_BookStore_Layer.Interfaces
{
    public interface IWishListManager
    {
        //Add to Wishlist
        public WishListEntity AddToWishList(int id, int bookid);
        public List<WishListEntity> GetAllWishlist(int id);
        public WishListEntity DeleteWishList(int id, int wishlistid);
    }
}
