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
    public class LogOutController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;

        public LogOutController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpPost]
        public IActionResult Logout(Logout logOut)
        {
            try
            {
                var FindUser =  _databaseContext.Users.SingleOrDefault(a => a.Username == logOut.Username);
                
                if(FindUser != null)
                {
                    return Ok(new {message= "Logout Success"});
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