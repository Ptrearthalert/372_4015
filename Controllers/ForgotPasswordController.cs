using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPI.DBContext;
using WebAPI.Models;



namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ForgotPasswordController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;

        public ForgotPasswordController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpPut]
        public IActionResult ForgetPassword(User user)
        {
            try
            {
                var ForgotPassword = _databaseContext.Users.SingleOrDefault(o => o.Id == user.Id);
                if(ForgotPassword != null)
                {
                    ForgotPassword.Password = user.Password;

                    _databaseContext.Users.Update(ForgotPassword);
                    _databaseContext.SaveChanges(); 
                    return Ok(new {message = "Repassword success"});
                }
                else
                {
                    return Ok(new {message = "Repassword Error"});
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new{result = ex.Message, message = "fail"});
            }
        }
    }
}