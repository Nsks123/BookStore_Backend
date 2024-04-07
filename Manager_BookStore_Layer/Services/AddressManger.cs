using Common_BookStore_Layer.RequestModel;
using Manager_BookStore_Layer.Interfaces;
using Repository_BookStore_Layer.BookStoreEntity;
using Repository_BookStore_Layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager_BookStore_Layer.Services
{
    public class AddressManger  : IAddressManager
    {
        private readonly IAddressRepository repository;
        public AddressManger(IAddressRepository repository)
        {
            this.repository = repository;
        }

        public AddressEntity AddAddress(AddAddressModel model, int id)
        {
            return repository.AddAddress(model, id);
        }
        public List<AddressEntity> GetAddresses(int id)
        {
            return repository.GetAddresses(id);
        }
        public AddressEntity UpdateAddress(UpdateAddressModel model, int id, int AddressId)
        {
            return repository.UpdateAddress(model, id, AddressId);
        }
    }
}
