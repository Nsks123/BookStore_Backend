using Common_BookStore_Layer;
using Common_BookStore_Layer.RequestModel;
using Common_BookStore_Layer.ResponseModel;
using Manager_BookStore_Layer.Interfaces;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Repository_BookStore_Layer.BookStoreContext;
using Repository_BookStore_Layer.BookStoreEntity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager userManager;
        private readonly IBus bus;
        private readonly UserContext userContext;
        private readonly IDistributedCache _cache;
        public UserController(IUserManager userManager,IBus bus,UserContext userContext,IDistributedCache _cache)
        {
            this.userManager = userManager;
            this.bus = bus;
            this.userContext = userContext;
            this._cache=_cache;
        }
        // User Registration
        [HttpPost]
        [Route("UserRegistration")]
        public ActionResult UserRegister(UserRegModel model)
        {
            try
            {
                var response = userManager.UserRegistration(model);
                if (response != null)
                {
                    return Ok(new ResModel<UserEntity> { Success = true, Message = " User Registration Success", Data = response });
                }
                else
                {
                    return BadRequest(new ResModel<UserEntity> { Success = false, Message = " User Registration Failed", Data = response });

                }
            }
            catch(Exception ex)
            {
                return BadRequest(new ResModel<UserEntity> { Success = false, Message = " User Registration Failed", Data = null });

            }
        }
        [HttpPost]
        [Route("UserLogin")]
        public ActionResult UserLogin(UserLoginModel model)
        {
            try
            {
                var response = userManager.UserLogin(model);
                if(response != null)
                {
                    return Ok(new ResModel<string> { Success = true, Message = "User Login Successful", Data = response });
                }
                else
                {
                    return BadRequest(new ResModel<string> { Success = false, Message = "User Login Failed", Data = response });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<string> { Success = false, Message = "User Login Failed", Data = null });
            }
        }
        // User Forgot Password
        [HttpPost]
        [Route("Forgot")]
        public async Task<ActionResult> ForgotPassword(string Email)
        {
            try
            {
                if (userManager.CheckEmail(Email))
                {
                    SendEmail mail = new SendEmail();
                    ForgotPasswordModel forgotPasswordModel = userManager.ForgetPass(Email);
                    var checkmail = userContext.UserTable.FirstOrDefault(x => x.Emailid == Email);
                    mail.SendMail(Email, forgotPasswordModel.token);
                    Uri uri = new Uri("rabbitmq://localhost/ticketQueue");
                    var endPoint = await bus.GetSendEndpoint(uri);
                    await endPoint.Send(forgotPasswordModel);
                    return Ok(new ResModel<string> { Success = true, Message = "Mail sent successfully", Data = forgotPasswordModel.token });

                }
                else
                {
                    return BadRequest(new ResModel<string> { Success = false, Message = "Email Does Not Exit", Data = Email });

                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<string> { Success = false, Message = "Exception: " + ex.Message, Data = null });
            }

        }
        // User Reset Password
        [Authorize]
        [HttpPost]
        [Route("Reset")]
        public ActionResult ResetPassword(ResetPasswordModel reset)
        {
            try
            {
                string Email = User.FindFirst("Emailid").Value;
                if (userManager.ResetPassword(Email, reset))
                {
                    return Ok(new ResModel<bool> { Success = true, Message = "Password Changed", Data = true });

                }
                else
                {
                    return BadRequest(new ResModel<bool> { Success = false, Message = "Password Not Changed", Data = false });
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
