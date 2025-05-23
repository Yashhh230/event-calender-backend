using EventCalender.Features.User.DTOs;
using EventCalender.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventCalender.Features.User.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        private readonly APIDbContext dbContext;

        public UserController(APIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("getUserList")]
        public IActionResult getUser()
        {
            return Ok(dbContext.user.ToList());

        }

        [HttpPost("saveUser")]
        public async Task<IActionResult> addUser(AddUserDTO addUserDTO)
        {
            try
            {
                var userData = new Models.Entities.User()
                {

                    FirstName = addUserDTO.FirstName,
                    LastName = addUserDTO.LastName,
                    Address = addUserDTO.Address,
                    Email = addUserDTO.Email,
                    PhoneNumber = addUserDTO.PhoneNumber,
                };

                await dbContext.user.AddAsync(userData);
                await dbContext.SaveChangesAsync();
                return Ok("");

            }
            catch(Exception e)
            {
                throw e;
            }
            //return Ok(dbContext.user.ToList());
        }

        [HttpGet("getUserById")]
        public async Task<IActionResult> getUserById([FromQuery] int id)
        {
            try
            {
                var userId = await dbContext.user.FindAsync(id);

                 if(userId == null)
                {
                    return NotFound();
                }
                return Ok(userId);
            }
            catch (Exception e)
            {
                throw e;
            }
            //return Ok(dbContext.user.ToList());
        }

        [HttpDelete("deleteUser")]
        public async Task<IActionResult> deleteUser([FromQuery] int id)
        {
            try
            {
                var userId = await dbContext.user.FindAsync(id);

                if (userId != null)
                {
                     dbContext.Remove(userId);
                     dbContext.SaveChanges();
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception e)
            {
                throw e;
            }
            //return Ok(dbContext.user.ToList());
        }
        [HttpPut("updateUser")]
        public async Task<IActionResult> updateUser([FromQuery] int id , AddUserDTO addUserDTO)
        {
            try
            {
                var userId = await dbContext.user.FindAsync(id);

                if (userId != null)
                {
                    userId.FirstName = addUserDTO.FirstName;
                    userId.LastName = addUserDTO.LastName;
                    userId.PhoneNumber = addUserDTO.PhoneNumber;
                    userId.Email = addUserDTO.Email;
                    userId.Address = addUserDTO.Address;

                    
                }
                dbContext.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                throw e;
            }
            //return Ok(dbContext.user.ToList());
        }
    }
}
