using Common_BookStore_Layer.RequestModel;
using Manager_BookStore_Layer.Interfaces;
using Repository_BookStore_Layer.BookStoreEntity;
using Repository_BookStore_Layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager_BookStore_Layer.Services
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository repository;
        public UserManager(IUserRepository repository)
        {
            this.repository = repository;
        }
        public UserEntity UserRegistration(UserRegModel model)
        {
            return repository.UserRegistration(model);
        }
        public string UserLogin(UserLoginModel model)
        {
            return repository.UserLogin(model);
        }
        public ForgotPasswordModel ForgetPass(string Email){ 
            return repository.ForgetPass(Email); 
        }
        public bool CheckEmail(string Email)
        {
            return repository.CheckEmail(Email);
        }
        public string GenerateToken(string Email, int Id)
        {
            return repository.GenerateToken(Email, Id);
        }

        public bool ResetPassword(string Email, ResetPasswordModel resetPasswordModel)
        {
            return repository.ResetPassword(Email, resetPasswordModel);
        }
    }
}
