using Common_BookStore_Layer.RequestModel;
using Common_BookStore_Layer.ResponseModel;
using Manager_BookStore_Layer.Interfaces;
using MassTransit;
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
    public class CartController : ControllerBase
    {
        private readonly ICartManager cartManager;
        public CartController(ICartManager cartManager)
        {
            this.cartManager = cartManager;
        }
        //Add  to Cart
        [Authorize]
        [HttpPost]
        [Route("AddCart")]
        public ActionResult AddCart(int bookid)
        {
            try
            {

                int id = Convert.ToInt32(User.FindFirst("User Id").Value);
                var response = cartManager.AddCart(id, bookid);
                if (response != null)
                {

                    return Ok(new ResModel<CartEntity> { Success = true, Message = "Added To Cart Success", Data = response });

                }
                else
                {
                    return BadRequest(new ResModel<CartEntity> { Success = false, Message = "Added To Cart Failed", Data = response });
                }
            }
            catch(Exception ex) 
            {
                return BadRequest(new ResModel<CartEntity> { Success = false, Message =ex.Message, Data = null });
            }
        }
        [Authorize]
        [HttpGet]
        [Route("GetAllCart")]
        public ActionResult GetAllCart()
        {
            

                int id = Convert.ToInt32(User.FindFirst("User Id").Value);
                var response = cartManager.GetAll(id);
                if (response != null)
                {

                    return Ok(new ResModel<List<CartEntity>> { Success = true, Message = "Get Cart Success", Data = response });

                }
                else
                {
                    return BadRequest(new ResModel<List<CartEntity>> { Success = false, Message = "Get Cart Failed", Data = response });
                }
            
            
        }
        [Authorize]
        [HttpPut]
        [Route("UpdateCart")]
        public ActionResult UpdateCart(int bookid)
        {
            try
            {

                int id = Convert.ToInt32(User.FindFirst("User Id").Value);
                var response = cartManager.UpdateCart(id, bookid);
                if (response != null)
                {

                    return Ok(new ResModel<CartEntity> { Success = true, Message = "Update To Cart Success", Data = response });

                }
                else
                {
                    return BadRequest(new ResModel<CartEntity> { Success = false, Message = "Update To Cart Failed", Data = response });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<CartEntity> { Success = false, Message = ex.Message, Data = null });
            }
        }
        [Authorize]
        [HttpPut]
        [Route("UpdateCart1")]
        public ActionResult UpdateCart1(int ProductId)
        {
            try
            {

                int id = Convert.ToInt32(User.FindFirst("User Id").Value);
                var response = cartManager.Removecart(id, ProductId);
                if (response != null)
                {

                    return Ok(new ResModel<CartEntity> { Success = true, Message = "Update To Cart Success", Data = response });

                }
                else
                {
                    return BadRequest(new ResModel<CartEntity> { Success = false, Message = "Update To Cart Failed", Data = response });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<CartEntity> { Success = false, Message = ex.Message, Data = null });
            }
        }
        [Authorize]
        [HttpDelete]
        [Route("DeleteCart")]
        public ActionResult DeleteCart(int cartid)
        {
            try
            {

                int id = Convert.ToInt32(User.FindFirst("User Id").Value);
                var response = cartManager.DeleteCart(id,cartid);
                if (response != null)
                {

                    return Ok(new ResModel<CartEntity> { Success = true, Message = "Delete Cart Success", Data = response });

                }
                else
                {
                    return BadRequest(new ResModel<CartEntity> { Success = false, Message = "Delete Cart Failed", Data = response });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<CartEntity> { Success = false, Message = ex.Message, Data = null });
            }
        }
        [Authorize]
        [HttpPut]
        [Route("OrderCart")]
        public ActionResult OrderCart()
        {
            try
            {

                int id = Convert.ToInt32(User.FindFirst("User Id").Value);
                var response = cartManager.OrderBook(id);
                if (response != null)
                {

                    return Ok(new ResModel<List<CartEntity>> { Success = true, Message = "Order Cart Success", Data = response });

                }
                else
                {
                    return BadRequest(new ResModel<List<CartEntity>> { Success = false, Message = "Order Cart Failed", Data = response });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<List<CartEntity>> { Success = false, Message = ex.Message, Data = null });
            }
        }

    }
}
