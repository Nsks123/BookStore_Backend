using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
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
        //Add Book
        public BookEntity CreateBook(CreateBookModel model)
        {
            BookEntity entity = new BookEntity();
            entity.BookName = model.BookName;
            entity.Description = model.Description;
            entity.Author = model.Author;
            entity.BookImage = UploadImage(model.BookImage,model.BookName);
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
        //Get All Books
        public List<BookEntity> GetAllBook()
        {
            return context.BookTable.ToList();

        }
        public BookEntity GetBookId(int id)
        {
            return context.BookTable.SingleOrDefault(o => o.BookId == id);
        }
        public List<BookEntity> GetBySearch(string author, string bookname)
        {
            return context.BookTable.Where(b=>b.Author.Contains(author) ||  b.BookName.Contains(bookname)).ToList();
        }
        public List<BookEntity> SortByPrice()
        {
            return context.BookTable.OrderBy(a=>a.DiscountPrice).ToList();
           
        }
        public List<BookEntity> SortByPriceDes()
        {
            return context.BookTable.OrderByDescending(a=>a.DiscountPrice).ToList();

        }
        public List<BookEntity> SortByArrivalAsc()
        { 

            return context.BookTable.OrderBy(a=>a.CreatedAt).ToList();
        }
        public List<BookEntity> SortByArrivalDes()
        {
            return context.BookTable.OrderByDescending(a => a.CreatedAt ).ToList();
        }
        public string UploadImage(string filepath,string bookname)
        {
            Account account = new Account("dygoi0kzf", "822117938224726", "DmntXzwnkbSDGj-depe7MShNlLU");
            Cloudinary cloudinary = new Cloudinary(account);
            ImageUploadParams uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(filepath),
                PublicId = bookname
            };
            ImageUploadResult uploadResult = cloudinary.Upload(uploadParams);
            return uploadResult.Url.ToString();
        }
    }
}
