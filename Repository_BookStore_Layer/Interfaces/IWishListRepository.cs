using Repository_BookStore_Layer.BookStoreEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository_BookStore_Layer.Interfaces
{
    public interface IWishListRepository
    {
        public WishListEntity AddToWishList(int id, int bookid);
        public List<WishListEntity> GetAllWishlist(int id);
        public WishListEntity DeleteWishList(int id, int wishlistid);
    }
}
