using Common_BookStore_Layer.RequestModel;
using Repository_BookStore_Layer.BookStoreEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager_BookStore_Layer.Interfaces
{
    public interface IBookManager
    {
        //Add Book
        public BookEntity CreateBook(CreateBookModel model);
        //Get All Books
        public List<BookEntity> GetAllBook();
        public BookEntity GetBookId(int id);
        public List<BookEntity> GetBySearch(string author, string bookname);
        public List<BookEntity> SortByPrice();
        public List<BookEntity> SortByPriceDes();
        public List<BookEntity> SortByArrivalAsc();
        public List<BookEntity> SortByArrivalDes();
    }
}
