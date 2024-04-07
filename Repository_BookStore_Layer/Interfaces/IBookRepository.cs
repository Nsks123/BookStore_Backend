using Common_BookStore_Layer.RequestModel;
using Repository_BookStore_Layer.BookStoreEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository_BookStore_Layer.Interfaces
{
    public interface IBookRepository
    {
        //Add Book
        public BookEntity CreateBook(CreateBookModel model);
        //Get All Books
        public List<BookEntity> GetAllBook();
        //Get All Books by BookId
        public BookEntity GetBookId(int id);
        //Get Book By Search
        public List<BookEntity> GetBySearch(string author, string bookname);
        //Sorting books by price in Ascending
        public List<BookEntity> SortByPrice();
        //Sorting books by price in Desending
        public List<BookEntity> SortByPriceDes();
        //Sorting books by new Arrival
        public List<BookEntity> SortByArrivalAsc();
        //Sorting books by new Arrival in Des
        public List<BookEntity> SortByArrivalDes();
    }
}
