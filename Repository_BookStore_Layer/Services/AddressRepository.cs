using Common_BookStore_Layer.RequestModel;
using Repository_BookStore_Layer.BookStoreContext;
using Repository_BookStore_Layer.BookStoreEntity;
using Repository_BookStore_Layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository_BookStore_Layer.Services
{
    public class AddressRepository :IAddressRepository
    {
        private readonly UserContext context;
        public AddressRepository(UserContext context)
        {
            this.context = context;
        }
        public AddressEntity AddAddress(AddAddressModel model,int id)
        {
            var address = context.AddressTable.SingleOrDefault(o=>o.UserId == id && o.Address==model.Address && o.City==model.City && o.State==model.State);
            if (address == null)
            {
                AddressEntity addressEntity = new AddressEntity();
                addressEntity.UserId = id;
                addressEntity.FullName = model.FullName;
                addressEntity.MobileNumber = model.MobileNumber;
                addressEntity.Address=model.Address;
                addressEntity.City = model.City;
                addressEntity.State = model.State;
                addressEntity.label=model.label;
                context.Add(addressEntity);
                context.SaveChanges();
                return addressEntity;
            }
            else
            {
                throw new Exception("Address is already using");
            }

        }
        public List<AddressEntity> GetAddresses(int id)
        {
            return context.AddressTable.Where(o=>o.UserId == id).ToList();
        }
        public AddressEntity UpdateAddress(UpdateAddressModel model,int id, int AddressId)
        {
            var update = context.AddressTable.SingleOrDefault(o => o.UserId == id && o.AddressId == AddressId);
            if(update !=null)
            {

                update.Address=model.Address;
                context.SaveChanges();
                return update;

            }
            else
            {
                throw new Exception("Address not Exist");
            }

        }
        
    }
}
