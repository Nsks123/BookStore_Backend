using Common_BookStore_Layer.RequestModel;
using Repository_BookStore_Layer.BookStoreEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository_BookStore_Layer.Interfaces
{
    public interface IBookRepository
    {
        public BookEntity CreateBook(CreateBookModel model);
        public List<BookEntity> GetAllBook();
        public List<BookEntity> GetBookId(int id);
        public List<BookEntity> GetBySearch(string author, string bookname);
        public List<BookEntity> SortByPrice();
        public List<BookEntity> SortByPriceDes();
        public List<BookEntity> SortByArrivalAsc();
        public List<BookEntity> SortByArrivalDes();
    }
}
