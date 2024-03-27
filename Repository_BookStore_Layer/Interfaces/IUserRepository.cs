using Common_BookStore_Layer.RequestModel;
using Repository_BookStore_Layer.BookStoreEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository_BookStore_Layer.Interfaces
{
    public interface IUserRepository
    {
        public UserEntity UserRegistration(UserRegModel model);
        public string UserLogin(UserLoginModel model);
        public ForgotPasswordModel ForgetPass(string Email);

        public bool CheckEmail(string Email);
        public string GenerateToken(string Email, int Id);

        public bool ResetPassword(string Email, ResetPasswordModel resetPasswordModel);


    }
}
