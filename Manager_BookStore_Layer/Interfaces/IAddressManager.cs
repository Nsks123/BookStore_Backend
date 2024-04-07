using Common_BookStore_Layer.RequestModel;
using Repository_BookStore_Layer.BookStoreEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager_BookStore_Layer.Interfaces
{
    public interface IAddressManager
    {

        public AddressEntity AddAddress(AddAddressModel model, int id);
        public List<AddressEntity> GetAddresses(int id);
        public AddressEntity UpdateAddress(UpdateAddressModel model, int id, int AddressId);
    }
}
