using Common_BookStore_Layer.ResponseModel;
using Manager_BookStore_Layer.Interfaces;
using Manager_BookStore_Layer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository_BookStore_Layer.BookStoreEntity;
using System;
using System.Collections.Generic;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        private readonly IWishListManager wishlistManager;
        public WishListController(IWishListManager wishlistManager)
        {
            this.wishlistManager = wishlistManager;
        }
        //Add to Wishlist
        [Authorize]
        [HttpPost]
        [Route("AddToWishList")]
        public ActionResult AddToWishListCart(int bookid)
        {
            try
            {

                int id = Convert.ToInt32(User.FindFirst("User Id").Value);
                var response = wishlistManager.AddToWishList(id, bookid);
                if (response != null)
                {

                    return Ok(new ResModel<WishListEntity> { Success = true, Message = "Added To WishList Success", Data = response });

                }
                else
                {
                    return BadRequest(new ResModel<WishListEntity> { Success = false, Message = "Added To WishList Failed", Data = response });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<WishListEntity> { Success = false, Message = ex.Message, Data = null });
            }
        }
        //Get All Wishlist
        [Authorize]
        [HttpGet]
        [Route("GetAllWishList")]
        public ActionResult GetAllWishList()
        {
            int id = Convert.ToInt32(User.FindFirst("User Id").Value);
            var response = wishlistManager.GetAllWishlist(id);
            if (response != null)
            {

                return Ok(new ResModel<List<WishListEntity>> { Success = true, Message = "Get All WishList Success", Data = response });

            }
            else
            {
                return BadRequest(new ResModel<List<WishListEntity>> { Success = false, Message = "Get All WishList Failed", Data = response });
            }
        }
        //Delete Wishlist
        [Authorize]
        [HttpDelete]
        [Route("DeleteWishList")]
        public ActionResult DeleteWishList(int wishlistid)
        {
            try
            {

                int id = Convert.ToInt32(User.FindFirst("User Id").Value);
                var response = wishlistManager.DeleteWishList(id, wishlistid);
                if (response != null)
                {

                    return Ok(new ResModel<WishListEntity> { Success = true, Message = "Delete WishList Success", Data = response });

                }
                else
                {
                    return BadRequest(new ResModel<WishListEntity> { Success = false, Message = "Delete  WishList Failed", Data = response });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<WishListEntity> { Success = false, Message = ex.Message, Data = null });
            }
        }
    }
}
