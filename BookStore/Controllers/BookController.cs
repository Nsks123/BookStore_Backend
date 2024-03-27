using Common_BookStore_Layer.RequestModel;
using Common_BookStore_Layer.ResponseModel;
using Manager_BookStore_Layer.Interfaces;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Repository_BookStore_Layer.BookStoreContext;
using Repository_BookStore_Layer.BookStoreEntity;
using System;
using System.Collections.Generic;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly IBookManager bookManager;
        public BookController(IBookManager bookManager)
        {
            this.bookManager = bookManager;
        }
        [HttpPost]
        [Route("AddBook")]
        public ActionResult AddBook(CreateBookModel model)
        {
            try
            {
                var response = bookManager.CreateBook(model);
                if (response != null)
                {
                    return Ok(new ResModel<BookEntity> { Success = true, Message = "Create Book Success", Data = response });
                }
                else
                {
                    return BadRequest(new ResModel<BookEntity> { Success = false, Message = " Create Book Failed", Data = response });

                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<BookEntity> { Success = false, Message = " Create Book Failed", Data = null });

            }
        }
        [HttpGet]
        [Route("GetAllBooks")]
        public ActionResult GetAllBooks()
        {
            try
            {
                var response = bookManager.GetAllBook();
                if(response !=null)
                {

                    return Ok(new ResModel<List<BookEntity>> { Success = true, Message = "Getting All Books Success", Data = response });

                }
                else
                {

                    return BadRequest(new ResModel<List<BookEntity>> { Success = false, Message = " Getting All Books Failed", Data = response });
                }
            }
            catch(Exception ex)
            {

                return BadRequest(new ResModel<List<BookEntity>> { Success = false, Message = " Getting All Books Failed", Data = null });
            }
        }
        [HttpGet]
        [Route("GetBookById")]
        public ActionResult GetBook(int id)
        {
            try
            {
                var response = bookManager.GetBookId(id);
                if (response != null)
                {

                    return Ok(new ResModel<List<BookEntity>> { Success = true, Message = "Get Book Success", Data = response });

                }
                else
                {

                    return BadRequest(new ResModel<List<BookEntity>> { Success = false, Message = " Get Book Failed", Data = response });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(new ResModel<List<BookEntity>> { Success = false, Message = " Get Book Failed", Data = null });
            }
        }
        [HttpGet]
        [Route("GetBookBySearch")]
        public ActionResult GetBySearch(string author,string bookname)
        {
            try
            {
                var response = bookManager.GetBySearch(author,bookname);
                if (response != null)
                {

                    return Ok(new ResModel<List<BookEntity>> { Success = true, Message = "Get Book Success", Data = response });

                }
                else
                {

                    return BadRequest(new ResModel<List<BookEntity>> { Success = false, Message = " Get Book Failed", Data = response });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(new ResModel<List<BookEntity>> { Success = false, Message = " Get Book Failed", Data = null });
            }
        }
        [HttpGet]
        [Route("SortPriceInAsc")]
        public ActionResult SortPriceInAsc()
        {
            try
            {
                var response = bookManager.SortByPrice();
                if (response != null)
                {

                    return Ok(new ResModel<List<BookEntity>> { Success = true, Message = "Sorted Price Success", Data = response });

                }
                else
                {

                    return BadRequest(new ResModel<List<BookEntity>> { Success = false, Message = " Sorted Price Failed", Data = response });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(new ResModel<List<BookEntity>> { Success = false, Message = " Sorted Price Failed", Data = null });
            }
        }
        [HttpGet]
        [Route("SortPriceInDes")]
        public ActionResult SortPriceInDes()
        {
            try
            {
                var response = bookManager.SortByPriceDes();
                if (response != null)
                {

                    return Ok(new ResModel<List<BookEntity>> { Success = true, Message = "Sorted Price Descending Success", Data = response });

                }
                else
                {

                    return BadRequest(new ResModel<List<BookEntity>> { Success = false, Message = " Sorted Price Descending Failed", Data = response });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(new ResModel<List<BookEntity>> { Success = false, Message = " Sorted Price Descending Failed", Data = null });
            }
        }
        [HttpGet]
        [Route("SortArrivalInAsc")]
        public ActionResult SortArrivalInAsc()
        {
            try
            {
                var response = bookManager.SortByArrivalAsc();
                if (response != null)
                {

                    return Ok(new ResModel<List<BookEntity>> { Success = true, Message = "Sorted Arrival Ascending Success", Data = response });

                }
                else
                {

                    return BadRequest(new ResModel<List<BookEntity>> { Success = false, Message = " Sorted Arrival Ascending Failed", Data = response });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(new ResModel<List<BookEntity>> { Success = false, Message = " Sorted Arrival Ascending Failed", Data = null });
            }
        }
        [HttpGet]
        [Route("SortArrivalInDes")]
        public ActionResult SortArrivalInDes()
        {
            try
            {
                var response = bookManager.SortByArrivalDes();
                if (response != null)
                {

                    return Ok(new ResModel<List<BookEntity>> { Success = true, Message = "Sorted Arrival Descending Success", Data = response });

                }
                else
                {

                    return BadRequest(new ResModel<List<BookEntity>> { Success = false, Message = " Sorted Arrival Descending Failed", Data = response });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(new ResModel<List<BookEntity>> { Success = false, Message = " Sorted Arrival Descending Failed", Data = null });
            }
        }


    }
}
