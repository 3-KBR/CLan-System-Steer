using System;
using Microsoft.AspNetCore.Mvc;
using Clan_System.Server.Services;
using Clan_System.Server.Models;

namespace Clan_System.Server.Controllers
{

    [Controller]
    [Route("api/[controller]")]
    
    public class UserController : Controller
    {

        private readonly UserService _userService;

        public UserController(UserService mongoDBService) 
        { 
            _userService = mongoDBService;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<List<User>> Get() 
        {
            Console.WriteLine("hi ma maaaaan");
            return await _userService.GetAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            await _userService.CreateAsync(user);
            return CreatedAtAction(nameof(Get), new { });
        }


        //To Chech If Username Exist
        [HttpPost]
        [Route("Check")]
        public async Task<ActionResult<User>> GetUserByUsername(User user)
        {
            var userFound = await _userService.GetUserByUsername(user.UserName);
            if (userFound == null)
            {
                return NotFound();
            }
            
            return userFound;
        }


        [HttpDelete("{username}")]
        public async Task<IActionResult> Delete(string username)
        {
            await _userService.DeleteAsync(username);
            return NoContent();
        }


        
    }
}
