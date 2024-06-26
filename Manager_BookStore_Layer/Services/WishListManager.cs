﻿using Manager_BookStore_Layer.Interfaces;
using Repository_BookStore_Layer.BookStoreEntity;
using Repository_BookStore_Layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager_BookStore_Layer.Services
{
    public class WishListManager : IWishListManager
    {
        private readonly IWishListRepository repository;
        public WishListManager(IWishListRepository repository)
        {
            this.repository = repository;
        }
        //Add to Wishlist
        public WishListEntity AddToWishList(int id, int bookid)
        {
            return repository.AddToWishList(id, bookid);
        }
        //Get All Wishlist
        public List<WishListEntity> GetAllWishlist(int id)
        {
            return repository.GetAllWishlist(id);
        }
        //Delete Wishlist
        public WishListEntity DeleteWishList(int id, int wishlistid)
        {
            return repository.DeleteWishList(id, wishlistid);
        }
    }
}
