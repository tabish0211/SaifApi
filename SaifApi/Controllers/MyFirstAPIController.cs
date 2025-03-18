using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaifApi.Data;
using SaifApi.Model;

namespace SaifApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MyFirstAPIController : ControllerBase
    {
        //static List<Customer> customers = new List<Customer> {
        //             new Customer { Id = 1, Name = "Saif", Address = "Dhaka" },
        //             new Customer { Id = 2, Name = "Rahim", Address = "Dhaka" }
        //         };

        private readonly MyDbContext _context;  

        public MyFirstAPIController(MyDbContext context)
        {
            _context = context;
                
        }
        [HttpGet]
        [ActionName("GetAllCustomers")]
        public async Task<IActionResult> Get()
        {
            var customers=_context.Customers.ToList();
            return Ok(customers);
        }

        [HttpGet]
        [ActionName("GetCusomrById")]
        public async Task<IActionResult> GetCusomrById([FromQuery]int id, [FromQuery]string name)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == id);
            return Ok(customer);
        }
        [HttpPost()]
        [ActionName("SaveCustomer")]
        public async Task<IActionResult> SaveCustomer([FromBody] Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return Ok("Record saved succesfully");
        }


        [HttpPut]
        [ActionName("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer([FromQuery]int id,[FromQuery] string name)
        {

            var customer = _context.Customers.FirstOrDefault(x => x.Id == id);
            if (customer is not null)
            {
                customer.Name = name;
                _context.SaveChanges();

            }
            else
            {
                return Ok($"Record not found for this customer={id}");
            }
            
            return Ok("Record is updated");
        }


        [HttpDelete]
        [ActionName("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer([FromQuery]int id)
        {

            var customer = _context.Customers.FirstOrDefault(x => x.Id == id);

            if (customer is not null)
            {
               _context.Customers.Remove(customer);
                _context.SaveChanges();

            }
            else
            {
                return Ok($"Record not found for this customer id={id}");
            }

            return Ok("Record is Deleted");
        }


    }
}
