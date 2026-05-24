using BLL;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TasksManger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepositroy _userRepositroy; 
        public UsersController(IUserRepositroy userRepositroy)
        {
           this._userRepositroy = userRepositroy;
        }

        [HttpGet("get")]
        public List<Users> GetUsers()
        {
            return _userRepositroy.GetAll();
        }

        [HttpGet("getById/{id}")]
        public ActionResult<Users> GetUsersById(int id)
        {
            Users users= _userRepositroy.GetById(id);
            if (users == null) 
                return NotFound();
            return Ok(users);
        }

        [HttpGet("getByName/{name}")]
        public ActionResult<List<Users>> GetUsersByName(string name)
        {
            return _userRepositroy.GetUsersByName(name);
        }

        [HttpPost("addUsers")]
        public ActionResult<Users> AddUsers(Users newUser)
        {
            if (newUser == null)
                return BadRequest();

            Users existingUser = _userRepositroy.GetById(newUser.UserId);

            if (existingUser != null || ModelState.IsValid)
                return Conflict("User already exists.");
            _userRepositroy.Add(newUser);
            _userRepositroy.SaveChanges();

            return CreatedAtAction(nameof(AddUsers), new { id = newUser.UserId }, newUser);
        }

        [HttpPut("update/{id}")]
        public ActionResult<Users> UpdateUsers(int id, Users users)
        {
            if (users == null || !ModelState.IsValid)
                return BadRequest();
            if (id != users.UserId)
                return Conflict();
            _userRepositroy.Update(users);
            _userRepositroy.SaveChanges();
            return Ok(users);
        }
        [HttpDelete("delete/{id}")]
        public ActionResult DeleteUsers(int id)
        {
            Users users = _userRepositroy.GetById(id);
            if (users == null)
                return NotFound();//404
            _userRepositroy.DeleteById(id);
            _userRepositroy.SaveChanges();

            return NoContent();
        }
    }
}
