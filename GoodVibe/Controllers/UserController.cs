using GoodVibe.Models.PropertyModels;
using GoodVibe.Models.UserModels;
using GoodVibe.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GoodVibe.Controllers
{
    [Route("api/UserApi")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsers _users;
        public UserController(IUsers users)
        {
            _users = users;
        }
        [HttpGet("AllUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserView>> GetAllUsers()
        {
            var model = await _users.GetAllUsers();
            return Ok(model);
        }
        [HttpGet("{id:int}", Name = "GetUserById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserView>> GetById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var model = await _users.GetById(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }
        [HttpPost("AddUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserAdd>> AddUser([FromBody] UserAdd userAdd)
        {
            var AddUser = await _users.AddUser(userAdd);
            if (AddUser != null)
            {
                return BadRequest("Failed to add property");
            }
            return Ok(AddUser);
        }
        [HttpPut("{id:int}", Name = "UpdateUser")]
        public async Task<ActionResult<UserUpdate>> UpdateUser(int id, [FromBody] UserUpdate userUpdate)
        {
            var AddUser = await _users.UpdateUser(userUpdate);

            if (userUpdate == null || id != userUpdate.Id)
            {
                return BadRequest();
            }
            return Ok(AddUser);
        }
    }
}