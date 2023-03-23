using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DBContext;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;

        public UserController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpGet]
        public IActionResult GetUser()
        {   
            try
            {
                var users = _databaseContext.Users.ToList(); 
                return Ok(new{result = users, message = "success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new{result = ex.Message, message = "fail" });
            }
        }

        
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {   
            try
            {
                var user = _databaseContext.Users.SingleOrDefault(o => o.Id == id); 
                return Ok(new{result = user, message = "success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new{result = ex.Message, message = "fail" });
            }
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {   
            try
            {
                _databaseContext.Users.Add(user);
                _databaseContext.SaveChanges();
                return Ok(new{message = "success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new{result = ex.Message, message = "fail" });
            }
        }

        [HttpPut]
        public IActionResult UpdateUser(User user)
        {   
            try
            {
                _databaseContext.Users.Update(user);
                _databaseContext.SaveChanges();
                return Ok(new{message = "success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new{result = ex.Message, message = "fail" });
            }
    
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {   
            try
            {
                var _user = _databaseContext.Users.SingleOrDefault(o => o.Id == id); 
                if(_user != null)
                {
                    _databaseContext.Users.Remove(_user);
                    _databaseContext.SaveChanges();
                    return Ok(new{message = "success"});
                }
                else
                {
                    return Ok(new{message = "fail"});
                }
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, new{result = ex.Message, message = "fail" });
            }
        }
    }
}
