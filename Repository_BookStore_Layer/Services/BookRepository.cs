using Common_BookStore_Layer.RequestModel;
using Microsoft.Extensions.Configuration;
using Repository_BookStore_Layer.BookStoreContext;
using Repository_BookStore_Layer.BookStoreEntity;
using Repository_BookStore_Layer.Interfaces;
using Repository_BookStore_Layer.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Unicode;

namespace Repository_BookStore_Layer.Services
{
    public class BookRepository :IBookRepository
    {
        private readonly UserContext context;
        public BookRepository(UserContext context)
        {
            this.context = context;
        }
        public BookEntity CreateBook(CreateBookModel model)
        {
            BookEntity entity = new BookEntity();
            entity.BookName = model.BookName;
            entity.Description = model.Description;
            entity.Author = model.Author;
            entity.BookImage = model.BookImage;
            entity.Price = model.Price;
            entity.DiscountPrice = model.DiscountPrice;
            entity.Quantity = model.Quantity;
            entity.Rating = model.Rating;
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;
            BookEntity user = context.BookTable.FirstOrDefault(a => a.BookName == model.BookName);
            if (user != null)
            {
                throw new Exception("Book Already Exist");
            }
            else
            {
                context.BookTable.Add(entity);
                context.SaveChanges();
                return entity;
            }
        }
        public List<BookEntity> GetAllBook()
        {
            return context.BookTable.ToList();

        }
        public List<BookEntity> GetBookId(int id)
        {
            return context.BookTable.Where(a=>a.BookId == id).ToList();
        }
        public List<BookEntity> GetBySearch(string author, string bookname)
        {
            return context.BookTable.Where(b=>b.Author.Contains(author) ||  b.BookName.Contains(bookname)).ToList();
        }
        public List<BookEntity> SortByPrice()
        {
            return context.BookTable.OrderBy(a=>a.Price).ToList();
           
        }
        public List<BookEntity> SortByPriceDes()
        {
            return context.BookTable.OrderByDescending(a=>a.Price).ToList();

        }
        public List<BookEntity> SortByArrivalAsc()
        { 

            return context.BookTable.OrderBy(a=>a.CreatedAt).ToList();
        }
        public List<BookEntity> SortByArrivalDes()
        {
            return context.BookTable.OrderByDescending(a => a.CreatedAt ).ToList();
        }
    }
}
