using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static readonly List<UserModel> userList = new List<UserModel>();
        [HttpGet]
        public IActionResult getUser()
        {
            return Ok(userList);
        }

        [HttpGet("{id}")]
        public IActionResult getUserById(int id)
        {
            var user = userList.FirstOrDefault((u) => { return u.Id == id; });
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult updateUser(int id, UserModel toUpdateUser)
        {
            var user = userList.FirstOrDefault((u) => { return u.Id == id; });
            if(user == null)
            {
                return NotFound();
            }
            user.Name = toUpdateUser.Name;
            user.Email = toUpdateUser.Email;
            user.Password = toUpdateUser.Password;
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult deleteUser(int id)
        {
            var user = userList.FirstOrDefault((u) => { return u.Id == id; });
            if(user == null)
            {
                return NotFound();
            }
            userList.Remove(user);
            return NoContent();
        }
    }
}
