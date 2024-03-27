using Common_BookStore_Layer.RequestModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repository_BookStore_Layer.BookStoreContext;
using Repository_BookStore_Layer.BookStoreEntity;
using Repository_BookStore_Layer.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Repository_BookStore_Layer.Services
{
    public class UserRepository:IUserRepository
    {
        private readonly UserContext context;
        private readonly IConfiguration config;
        public UserRepository(UserContext context,IConfiguration config)
        {
            this.context = context;
            this.config = config;
        }
        
        public UserEntity UserRegistration(UserRegModel model)
        {
            UserEntity entity = new UserEntity();
            entity.FullName = model.FullName;
            entity.Emailid = model.Emailid;
            entity.Password = Encryption("s25ed698a3q89dnc982jsuenm874mdk9", model.Password);
            entity.MobileNumber = model.MobileNumber;
            UserEntity user=context.UserTable.FirstOrDefault(a=>a.Emailid == model.Emailid);
            if (user != null)
            {
                throw new Exception("User Already Exist");
            }
            else
            {
                context.UserTable.Add(entity);
                context.SaveChanges();
                return entity;
            }

        }
       
        public string UserLogin(UserLoginModel model)
        {
           
            var user = context.UserTable.SingleOrDefault(o => o.Emailid == model.Emailid );
            string password = Decryption("s25ed698a3q89dnc982jsuenm874mdk9", user.Password);


            if (user != null)
            {

                if (password == model.Password)
                {
                    var token=GenerateToken(user.Emailid,user.UserId);
                    return token;
                }
                else
                {
                    throw new Exception("Invalid Password");
                }
            }
            else
            {
                throw new Exception("User Not Found");
            }         
        }
        
        public string Encryption(string key, string Password)
        {
            byte[] Initial_Vector = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {

                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = Initial_Vector;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(Password);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }
        
        public string Decryption(string key, string Password)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(Password);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
        public bool CheckEmail(string Email)
        {
            return context.UserTable.Any(x => x.Emailid == Email);
        }
        public string GenerateToken(string Emailid, int UserId)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("Emailid",Emailid),
                new Claim("User Id",UserId.ToString())
            };
            var token = new JwtSecurityToken(config["Jwt:Issuer"],
                config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddHours(24),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }
        public ForgotPasswordModel ForgetPass(string Email)
        {
            var user = context.UserTable.FirstOrDefault(x => x.Emailid == Email);
            if (user != null)
            {
                ForgotPasswordModel password = new ForgotPasswordModel();
                password.Emailid = Email;
                password.Id = Convert.ToString(user.UserId);
                password.token = GenerateToken(user.Emailid, user.UserId);
                return password;
            }
            else
            {
                throw new Exception();
            }

        }
        public bool ResetPassword(string Email, ResetPasswordModel resetPasswordModel)
        {
            UserEntity user = context.UserTable.ToList().Find(user => user.Emailid == Email);
            if (user != null)
            {
                user.Password = Encryption("s25ed698a3q89dnc982jsuenm874mdk9", resetPasswordModel.ConfirmPassword);

                context.SaveChanges();
                return true;

            }
            else
            {
                return false;
            }

        }

    }
}
