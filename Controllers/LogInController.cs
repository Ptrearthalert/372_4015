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
    public class LogInController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;

        public LogInController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpPost]
        public IActionResult Login(LogIn logIn)
        {
            try
            {
                var FindUser =  _databaseContext.Users.SingleOrDefault(a => a.Username == logIn.Username && a.Password == logIn.Password);
                
                if(FindUser != null)
                {
                    return Ok(new {message= "Login Success"});
                }
                else
                {
                    return Ok(new {message= "Username or Password Wrong"});
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new {result = ex.Message, message = "fail"});
            }
        }
    }
}