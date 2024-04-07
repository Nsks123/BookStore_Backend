using Common_BookStore_Layer.RequestModel;
using Repository_BookStore_Layer.BookStoreEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager_BookStore_Layer.Interfaces
{
    public interface IUserManager
    {
        // User Registration
        public UserEntity UserRegistration(UserRegModel model);
        public string UserLogin(UserLoginModel model);
        // User Forgot Password
        public ForgotPasswordModel ForgetPass(string Email);

        public bool CheckEmail(string Email);
        // User Reset Password
        public bool ResetPassword(string Email, ResetPasswordModel resetPasswordModel);


    }
}
