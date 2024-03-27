using System;
using System.Collections.Generic;
using System.Text;

namespace Common_BookStore_Layer.RequestModel
{
    public class ForgotPasswordModel
    {
        public string Id { get; set; }
        public string Emailid { get; set; }
        public string token { get; set; }
    }
}
