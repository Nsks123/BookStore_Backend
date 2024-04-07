using Common_BookStore_Layer.RequestModel;
using Manager_BookStore_Layer.Interfaces;
using Repository_BookStore_Layer.BookStoreEntity;
using Repository_BookStore_Layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager_BookStore_Layer.Services
{
    public class BookManager :IBookManager
    {
        private readonly IBookRepository repository;
        public BookManager(IBookRepository repository)
        {
            this.repository = repository;
        }
        //Add Book
        public BookEntity CreateBook(CreateBookModel model)
        {
            return repository.CreateBook(model);
        }
        //Get All Books
        public List<BookEntity> GetAllBook()
        {
            return repository.GetAllBook();
        }
        //Get All Books by BookId
        public BookEntity GetBookId(int id)
        {
            return repository.GetBookId(id);
        }
        //Get Book By Search
        public List<BookEntity> GetBySearch(string author, string bookname)
        {
            return repository.GetBySearch(author, bookname);
        }
        public List<BookEntity> SortByPrice()
        {
            return repository.SortByPrice();
        }
        public List<BookEntity> SortByPriceDes()
        {
            return repository.SortByPriceDes();
        }
        public List<BookEntity> SortByArrivalAsc()
        {
            return repository.SortByArrivalAsc();
        }
        public List<BookEntity> SortByArrivalDes()
        {
            return repository.SortByArrivalDes();
        }

    }

}
