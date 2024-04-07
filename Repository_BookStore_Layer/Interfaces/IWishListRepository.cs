using Repository_BookStore_Layer.BookStoreEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository_BookStore_Layer.Interfaces
{
    public interface IWishListRepository
    {
        //Add to Wishlist
        public WishListEntity AddToWishList(int id, int bookid);
        //Get All Wishlist
        public List<WishListEntity> GetAllWishlist(int id);
        //Delete Wishlist
        public WishListEntity DeleteWishList(int id, int wishlistid);
    }
}
