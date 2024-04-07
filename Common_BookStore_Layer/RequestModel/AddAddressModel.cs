using System;
using System.Collections.Generic;
using System.Text;

namespace Common_BookStore_Layer.RequestModel
{
    public class AddAddressModel
    {

        public string FullName { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string label { get; set; }
    }
}
