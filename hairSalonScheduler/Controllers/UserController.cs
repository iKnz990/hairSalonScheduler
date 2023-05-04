using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using hairSalonScheduler.Interfaces;
using hairSalonScheduler.Models;

namespace hairSalonScheduler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/user
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return Ok(users);
        }

        // GET: api/user/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST: api/user
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] AppUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _userRepository.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        // PUT: api/user/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] AppUser user)
        {
            if (id != user.Id)
            {
                return BadRequest("User ID in the URL and the user object do not match.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _userRepository.UpdateUserAsync(user);
            }
            catch 
            {
                // You might want to log the exception details here.
                return StatusCode(500, "An error occurred while updating the user.");
            }

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PartiallyUpdateUser(int id, [FromBody] JsonPatchDocument<AppUser> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var existingUser = await _userRepository.GetUserByIdAsync(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            patchDoc.ApplyTo(existingUser, (Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter)ModelState, (error) =>
            {
                var path = error.AffectedObject.GetType().Name;
                ModelState.AddModelError(path, error.ErrorMessage);
            });

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _userRepository.UpdateUserAsync(existingUser);
            return NoContent();
        }

        // DELETE: api/user/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            await _userRepository.DeleteUserAsync(id);
            return NoContent();
        }
    }
}