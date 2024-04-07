using Common_BookStore_Layer.RequestModel;
using Common_BookStore_Layer.ResponseModel;
using Manager_BookStore_Layer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository_BookStore_Layer.BookStoreEntity;
using System.Collections.Generic;
using System;
using Manager_BookStore_Layer.Services;
using Microsoft.AspNetCore.Authorization;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressManager manager;
        public AddressController(IAddressManager manager)
        {
            this.manager = manager;
        }
        [Authorize]
        [HttpPost]
        [Route("AddAddress")]
        public ActionResult AddAddress(AddAddressModel model)
        {
            try
            {

                int id = Convert.ToInt32(User.FindFirst("User Id").Value);
                var response = manager.AddAddress(model,id);
                if (response != null)
                {

                    return Ok(new ResModel<AddressEntity> { Success = true, Message = "Added Address Success", Data = response });

                }
                else
                {
                    return BadRequest(new ResModel<AddressEntity> { Success = false, Message = "Added Address Failed", Data = response });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<AddressEntity> { Success = false, Message = ex.Message, Data = null });
            }
        }
        [Authorize]
        [HttpGet]
        [Route("GetAllAddress")]
        public ActionResult GetAllAddress()
        {


            int id = Convert.ToInt32(User.FindFirst("User Id").Value);
            var response = manager.GetAddresses(id);
            if (response != null)
            {

                return Ok(new ResModel<List<AddressEntity>> { Success = true, Message = "Get All Address Success", Data = response });

            }
            else
            {
                return BadRequest(new ResModel<List<AddressEntity>> { Success = false, Message = "Get  All Address Failed", Data = response });
            }


        }
        [Authorize]
        [HttpPut]
        [Route("UpdateAddress")]
        public ActionResult UpdateAddress(UpdateAddressModel model,int AddressId)
        {
            try
            {

                int id = Convert.ToInt32(User.FindFirst("User Id").Value);
                var response = manager.UpdateAddress(model,id,AddressId);
                if (response != null)
                {

                    return Ok(new ResModel<AddressEntity> { Success = true, Message = "Updated Address Success", Data = response });

                }
                else
                {
                    return BadRequest(new ResModel<AddressEntity> { Success = false, Message = "Updated Address Failed", Data = response });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<AddressEntity> { Success = false, Message = ex.Message, Data = null });
            }
        }
    }
}
