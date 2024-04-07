using Microsoft.EntityFrameworkCore;
using Repository_BookStore_Layer.BookStoreEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository_BookStore_Layer.BookStoreContext
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
        public DbSet<UserEntity> UserTable { get; set; }
        public DbSet<BookEntity> BookTable { get; set; }
        public DbSet<CartEntity> CartTable { get; set; }
        public DbSet<WishListEntity> WishListTable { get; set;}
        public DbSet<AddressEntity> AddressTable { get; set; }  

    }
}
