using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaifApi.Data;
using SaifApi.Model;

namespace SaifApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //static List<Customer> customers = new List<Customer> {
        //             new Customer { Id = 1, Name = "Saif", Address = "Dhaka" },
        //             new Customer { Id = 2, Name = "Rahim", Address = "Dhaka" }
        //         };

        private readonly MyDbContext _context;  

        public UserController(MyDbContext context)
        {
            _context = context;
                
        }
        [HttpGet]
        [ActionName("GetAllUsers")]
        public async Task<IActionResult> Get()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }

        [HttpGet]
        [ActionName("GetUserId")]
        public async Task<IActionResult> GetUserId([FromQuery] string userId)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserId == userId);
            return Ok(user);
        }
        [HttpPost()]
        [ActionName("Saveuser")]
        public async Task<IActionResult> Saveuser([FromBody] User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok("Record saved succesfully");
        }


        [HttpPut]
        [ActionName("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromQuery] string userId, [FromBody] User user)
        {

            var User = _context.Users.FirstOrDefault(x => x.UserId == userId);
            if (User is not null)
            {
                User.Name = user.Name;
                _context.SaveChanges();

            }
            else
            {
                return Ok($"Record not found for this UserId={userId}");
            }

            return Ok("Record is updated");
        }


        [HttpDelete]
        [ActionName("DeleteUser")]
        public async Task<IActionResult> DeleteUser([FromQuery] string userId)
        {

            var user = _context.Users.FirstOrDefault(x => x.UserId == userId);

            if (user is not null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();

            }
            else
            {
                return Ok($"Record not found for this UserId= {userId}");
            }

            return Ok("Record is Deleted");
        }


    }
}
